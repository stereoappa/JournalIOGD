using DomainModel.Entities;
using LoadOfSql.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace LoadOfSql.Infrastructure
{
    public static class PrintingManager
    {
        static string templatePath = GlobalSettings.PrintTemplatePath;
        static void FillingAllWordStub(Word.Document wordDocument, int id, DateTime date, List<Document> docs, string orgName,
                                     string clientName, string identityClientName, string cost, string memo, string paymentStatus, string employee, Sign sign, string entryType = "")
        {
            try
            {
                AddValueOfBookmark("id", id.ToString(), wordDocument);
                AddValueOfBookmark("date", date.ToShortDateString(), wordDocument);
                AddValueOfBookmark("numRazresh", (GenerateRequisites(docs)), wordDocument);
                AddValueOfBookmark("memo", memo, wordDocument);
                AddValueOfBookmark("orgName", orgName, wordDocument);
                AddValueOfBookmark("clientName", identityClientName, wordDocument);
                AddValueOfBookmark("clientName2", clientName, wordDocument);
                AddValueOfBookmark("typeDoc", docs.Count > 0 ?  docs.GetDocsType().ToStringName() : entryType, wordDocument);
                if (cost == "0" || cost == "бесплатно")
                    AddValueOfBookmark("cost", "бесплатно", wordDocument);
                else
                    AddValueOfBookmark("cost", cost + " руб.", wordDocument);
                AddValueOfBookmark("paymentStatus", paymentStatus, wordDocument);
                AddValueOfBookmark("employee", employee, wordDocument);

                AddValueOfBookmark("directorPost", sign.Owner.Post, wordDocument);
                AddValueOfBookmark("directorName", sign.Owner.ShortName, wordDocument);

                AddImageOfBookmark("directorSign", sign.GetBitmapSign(), wordDocument);
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось заполнить шаблоны подстановки в документе Word." + ex.Message);
            }
        }

        private static void AddImageOfBookmark(string v, Bitmap bitmap, Word.Document wordDocument)
        {
            var r = wordDocument.Bookmarks[v].Range;
            Clipboard.SetDataObject(bitmap);
            r.Paste();
            
            //wordDocument.InlineShapes.AddPicture("D:\\Гончарова_sign.jpg", ref missing, ref saveWithDocument, ref r);
        }

        private static void AddValueOfBookmark(string bookmarkName, string value, Word.Document wordDocument)
        {
            if (wordDocument.Bookmarks.Exists(bookmarkName))
               wordDocument.Bookmarks[bookmarkName].Range.Text = value;
        }

        public static void Print(int id, DateTime date, List<Document> docs, string orgName,
                                     string clientName, string identityClienName, string cost, string memo, string paymentStatus, string employee, Sign sign, string entryType = "")
        {
            GlobalSettings.SetReadOnlyProp(templatePath);

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(templatePath);               
                FillingAllWordStub(wordDocument, id, date, docs, orgName, clientName, identityClienName, cost, memo, paymentStatus, employee, sign, entryType);
                GlobalSettings.Printers();
                wordApp.ActivePrinter = GlobalSettings.printers[GlobalSettings.SelectPrinter];
                wordApp.PrintOut(Background: true);

                wordDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
            catch
            {
                wordApp.Quit();
                throw new Exception("Ошибка печати. Проверьте настройки принтера и путь к шаблону печати.");
            }
            finally
            {
                wordApp.Quit();
            }
        }


        public static void ExportToWord(int id, DateTime date, List<Document> docs, string orgName,
                                     string clientName, string identityClientName, string cost, string memo, string paymentStatus, string employee, Sign sign, string entryType = "")
        {
            GlobalSettings.SetReadOnlyProp(templatePath);
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var wordDocument = wordApp.Documents.Open(templatePath);
                FillingAllWordStub(wordDocument, id, date, docs, orgName, clientName, identityClientName, cost, memo, paymentStatus, employee, sign, entryType);

                wordApp.Visible = true;
            }
            catch
            {
                wordApp.Quit();
                throw new Exception("Не удалось отобразить запись в документ Word. Возможно, файл-шаблон не существует, либо поле Описания имеет слишком большой объем");
            }
        }
        static string GenerateRequisites(List<Document> docsForPrint)
        {
            string result = "";
            if (docsForPrint != null)
            {
                DocType type = docsForPrint.GetDocsType();

                if (type == DocType.Ticket)
                    foreach (Document item in docsForPrint)
                    {
                        var ticketNum = item.TicketNumber == null ? "" : "№ " + item.TicketNumber.Trim();
                        var ticketDate = item.TicketDate == null ? "" : " от " + item.TicketDate.Value.ToShortDateString();

                        result += ticketNum + ticketDate + ";" + Environment.NewLine;
                    }

                if (type == DocType.Permission)
                    foreach (Document doc in docsForPrint)
                    {
                        var numRazresh = doc.NumRazresh == null ? "" : "№ " + doc.NumRazresh.Trim();
                        var dateRazresh = doc.DateRazresh == null ? "" : " от " + doc.DateRazresh.Value.ToShortDateString();
                        var ticketNum = doc.TicketNumber == null ? "" : " (обр. № " + doc.TicketNumber.Trim();
                        var ticketDate = doc.TicketDate == null ? "" : " от " + doc.TicketDate.Value.ToShortDateString()+")";

                        result += numRazresh + dateRazresh + ticketNum + ticketDate + ";" + Environment.NewLine;
                    }
            }
            else
                return "-";

            return result; //.Replace("\r\n", "^p");
        }
        //static void ReplaceMemoStub(string memo, Word.Document wordDocument)
        //{
        //    string text;
        //    string text_continue;
        //    string text_continue_2;
        //    int parts = memo.Length / 240;
        //    if (memo.Length % 240 > 0)
        //        parts++;
        //    switch (parts)
        //    {
        //        case 1:
        //            {
        //                ReplaceWordStub("{memo}", memo.Replace("\r\n", "^p"), wordDocument);
        //                break;
        //            }
        //        case 2:
        //            {
        //                if (memo.Length % 2 > 0)
        //                {
        //                    text = memo.Substring(0, (memo.Length / 2) + 1);
        //                    text_continue = memo.Substring(text.Length, text.Length - 1);
        //                }
        //                else
        //                {
        //                    text = memo.Substring(0, memo.Length / 2);
        //                    text_continue = memo.Substring(text.Length, text.Length);
        //                }
        //                ReplaceWordStubForMemo("{memo}", text.Replace("\r\n", "^p"), text_continue.Replace("\r\n", "^p"), wordDocument);
        //                break;
        //            }
        //        case 3:
        //            {
        //                text = memo.Substring(0, 240);
        //                text_continue = memo.Substring(240, 240);
        //                text_continue_2 = memo.Substring(480);

        //                ReplaceWordStubForMemo("{memo}", text.Replace("\r\n", "^p"), text_continue.Replace("\r\n", "^p"), text_continue_2.Replace("\r\n", "^p"), wordDocument);
        //                break;
        //            }
        //    }
        //}
        //static void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        //{
        //    var range = wordDocument.Content;
        //    range.Find.ClearFormatting();
        //    range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        //}
        //static void ReplaceWordStubForMemo(string stubToReplace, string text, string text_continue, Word.Document wordDocument)
        //{
        //    var range = wordDocument.Content;
        //    range.Find.ClearFormatting();
        //    range.Find.Execute(FindText: stubToReplace, ReplaceWith: text + "{memo_continue}");
        //    range.Find.Execute(FindText: "{memo_continue}", ReplaceWith: text_continue);
        //}
        //static void ReplaceWordStubForMemo(string stubToReplace, string text, string text_continue, string text_continue_2, Word.Document wordDocument)
        //{
        //    var range = wordDocument.Content;
        //    range.Find.ClearFormatting();
        //    range.Find.Execute(FindText: stubToReplace, ReplaceWith: text + "{memo_continue}");
        //    range.Find.Execute(FindText: "{memo_continue}", ReplaceWith: text_continue + "{memo_cont_2}");
        //    range.Find.Execute(FindText: "{memo_cont_2}", ReplaceWith: text_continue_2);
        //}
    }
}
