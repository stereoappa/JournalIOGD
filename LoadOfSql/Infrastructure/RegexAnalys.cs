using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LoadOfSql
{
    static class RegexAnalys
    {
        #region Анализ колличества планшетов в строке
        public static int MapCasesCount(string text)
        {
            int sumMapCases = 0;
            string pattern = @"\b\d{1,2}[АаБбВвГг](([0][1-9])|([1][0-6]))(?![\w])";
            Regex regFullSign = new Regex(pattern);
            //MatchCollection fullNamesCollection = regFullSign.Matches(text);

            //Если есть одинаковые имена то удалим их из коллекции. Перетащим в List и воспользуемся методом Distinct из LINQ
            string[] distinct_matches = distinct_matches = regFullSign.Matches(text)
                                       .Cast<Match>()
                                       .Select(m => m.Value.ToString())
                                       .Distinct().ToArray<string>();
            sumMapCases += distinct_matches.Length;

            Regex extRegTire;      //Ищем строки типа "56г05-07, 08" и пробуем посчитать количество в промежутке. И типы 55Г07-55Г12
            foreach (string fmatch in distinct_matches)
            {
                Regex extSimpleComma;
                string view_pattern = @"(?<=(?<!-\s*)" + fmatch + @"(?![\w])(\s*,\s*)(([0][1-9])|([1][0-6]))(?-)(?![аА-яЯaA-zZ0-9]))";
                extSimpleComma = new Regex(view_pattern);
                MatchCollection extCommaMatchColl = extSimpleComma.Matches(text);
                if (extCommaMatchColl.Count > 0)
                {
                    //sumMapCases += 1; // тут всегда еденица будет;
                    sumMapCases += FindNext(fmatch, text);        // перечисление через запятую типа 56Г07, 12,14    
                }
                //=============================================================================================================
                string tire_pattern = @"(?<=" + fmatch + @"(?![\w]))(\s*-\s*)(([0][1-9])|([1][0-6]))(?![-аА-яЯaA-zZ0-9])";
                extRegTire = new Regex(tire_pattern);
                MatchCollection extMatchColl = extRegTire.Matches(text);
                foreach (Match rightTireMatch in extMatchColl)
                {
                    sumMapCases += CasesDiapasonCounter(fmatch + rightTireMatch) - 1;
                    sumMapCases += FindNext(tire_pattern, text);        //Если нашлось тире пытаемся проверить не идет ли за ним перечисление через запятую типа 56Г07-09, 12,14    
                }
                //=============================================================================================================
                //Ищем 55Г07 - 55Г09
                Regex extRegTireFn;
                string tire_pattern_fn = @"((?<=" + fmatch + @"(?![\w])(\s*-\s*)(" + fmatch.Substring(0, 3) + @"))(([0][1-9])|([1][0-6]))(?![\w]))(?![-аА-яЯaA-zZ0-9])";
                extRegTireFn = new Regex(tire_pattern_fn);
                MatchCollection fnTireCol = extRegTireFn.Matches(text);
                foreach (Match rightTireMatch in fnTireCol)
                {
                    sumMapCases += CasesDiapasonCounter(fmatch + "-" + rightTireMatch) - 2;
                    sumMapCases += FindNext(tire_pattern_fn, text);
                }
            }
            return sumMapCases;
        }

        private static int FindNext(string pattern, string text)
        {
            int sum = 0;
            sum += FindNextTiresAndCommasCombinations(pattern, text);   //Закомментировать

            return sum;
        }

        private static int FindNextTiresAndCommasCombinations(string pattern, string text)
        {
            int sum = 0;
            string next_tire = @"((\s*,\s*)(([0][1-9])|([1][0-6]))(\s{0,2}-\s{0,2})(([0][1-9])|([1][0-6]))(?![-аА-яЯaA-zZ0-9]))"; //тире следующее за 07, 09(, 11 - 14)        
            string next_tire_internal;
            while (true)
            {
                while (true)        //если найдет 08-09, 12 то паттерн расширяем до этой запятой
                {
                    int next_commas = ExtToCommaAndNextNumber(ref pattern, text);
                    if (next_commas != 0)
                    {
                        sum += next_commas;
                        continue;
                    }
                    else break;
                }

                next_tire_internal = "(?<=" + pattern + ")" + next_tire;

                Regex extregTire;
                extregTire = new Regex(next_tire_internal);      //ОШИБКА!!!! next_tire должен опираться на обычное значение 55г15, Диапазоны ,06-08 считаются дважды
                MatchCollection commaAndNextTire = extregTire.Matches(text);
                if (commaAndNextTire.Count > 0)
                {
                    foreach (Match match in commaAndNextTire)       
                    {
                        sum += CasesDiapasonCounter(match.Value);
                        pattern += @"((\s*,\s*)(([0][1-9])|([1][0-6]))(\s{0,2}-\s{0,2})(([0][1-9])|([1][0-6]))(?![-аА-яЯaA-zZ0-9]))";
                    }
                    continue;
                }
                else break;
            }
            //while (true)
            //{

            //    int next_commas = ExtToCommaAndNextNumber(ref pattern, text);  //если найдет 08-09, 12 то паттерн нужно будет расширить до этой запятой
            //    //pattern += next_tire;
            //    if (next_commas != 0)
            //        sum += next_commas;
            //    else break;
            //}
            // break;


            //MessageBox.Show(commaAndNextTire[0].Value.ToString());
            return sum;
        }

        private static int ExtToCommaAndNextNumber(ref string pattern, string text)
        {
            Regex extRegCommaAfterTire;
            string internal_pattern = pattern;
            int sum = 0;
            while (true)
            {
                internal_pattern += @"(\s*,*\s*)(([0][1-9])|([1][0-6]))(?!(\s{0,2}-))(?![-аА-яЯaA-zZ0-9])";

                extRegCommaAfterTire = new Regex(internal_pattern);
                MatchCollection extTireAndCommaColl = extRegCommaAfterTire.Matches(text);
                if (extTireAndCommaColl.Count > 0)
                {
                    pattern += @"(\s*,*\s*)(([0][1-9])|([1][0-6]))(?!(\s{0,2}-))(?![-аА-яЯaA-zZ0-9])";
                    sum += extTireAndCommaColl.Count;
                    continue;
                }
                else
                {
                    break;
                }
            }
            return sum;
        }

        private static int CasesDiapasonCounter(string dirtryForFindDiapasone)   // из строки вычленияем сущности типа "(-)09" и "09(-)" и считаем количество
        {
            int sum = 0;

            string pattern_findDiapason = @"(([0][1-9])|([1][0-6]))(\s*-\s*)(?![аА-яЯaA-zZ])(([0][1-9])|([1][0-6]))";
            Regex clearDiapason = new Regex(pattern_findDiapason);

            MatchCollection leftAndRightDiapason = clearDiapason.Matches(dirtryForFindDiapasone);
            foreach (Match m_diapasone in leftAndRightDiapason)  //ну при вызове из find next tires тут всего 1 совпадение должно быть
            {
                string beforeTire = m_diapasone.Value.Substring(0, 2);
                string afterTire = m_diapasone.Value.Substring(m_diapasone.Value.Length - 2);

                int beforeTireInt;
                int afterTireInt;
                int.TryParse(beforeTire, out beforeTireInt);
                int.TryParse(afterTire, out afterTireInt);

                sum += Math.Abs(afterTireInt - beforeTireInt) + 1;
            }
            return sum;
        }

        private static MatchCollection ChoseMaxIntersectDiapason(MatchCollection extMatchColl)
        {
            return extMatchColl;
        }

        #endregion

        public static List<int> ParseNumbersDiapasone(string cellText)
        {
            if (cellText == String.Empty)
                return null;

            List<int> results = new List<int>();

            Regex pattern = new Regex(@"\d{1,4}\s{0,1}-\s{0,1}\d{1,4}");

            MatchCollection matchCollection = pattern.Matches(cellText);
            if (matchCollection.Count > 0)
            {
                foreach (Match item in matchCollection)
                {
                    string[] tireValues = item.Value.Replace(" ", "").Split('-');
                    //if (int.Parse(tireValues[0]) > int.Parse(tireValues[1]))
                    //{
                    //    return null;
                    //}

                    int min = Math.Min(int.Parse(tireValues[0]), int.Parse(tireValues[1]));
                    int max = Math.Max(int.Parse(tireValues[0]), int.Parse(tireValues[1]));
                    if (min >= max)
                        return null;

                    for (int i = min, k = 0; i <= max; i++, k++)
                    {
                        //Добавляем все значения из диапазона в результирующую коллекцию
                        results.Add(i);             
                    }

                    //Удаляем диапазон из исходной строки
                    cellText = cellText.Replace(item.Value.ToString(), ""); 
                }
            }
            //Если случайно были введены некорректные символы заменим их на запятые. И удалим все пробелы
            cellText = cellText.Replace(";", ",").Replace(".", ",").Replace(",,", ",").Replace(" ", "");

            string[] commaValues = cellText.Split(',');
            int parseValue;
            for (int i = 0; i < commaValues.Length; i++)
            {
                bool parseOK = int.TryParse(commaValues[i], out parseValue);
                if (parseOK)                 
                    results.Add(parseValue);
            }

            return results;

        }
    }
}
