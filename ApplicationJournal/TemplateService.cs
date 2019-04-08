using DomainModel.Entities;
using DomainModel.Helpers;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApplicationJournal
{
    public class TemplateService : ITemplateService
    {
        ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            AvailableTemplates = _templateRepository.GetTemplateTypes();
            IssueTemplatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                AvailableTemplates.First(t => t.TypeId == TemplateTypeId.InformationIssueTemplate).Name + ".docx");
        }

        public List<TemplateType> AvailableTemplates { get; }
        public string IssueTemplatePath { get; }
                   

        public void LoadActualIssueTemplate()
        {
            var issueTemplate = _templateRepository.GetActualTemplate(TemplateTypeId.InformationIssueTemplate, false);
            if(issueTemplate == null)
            {
                throw new FileNotFoundException("Шаблон о выдаче информации пока не загружен.\r\n\r\n" +
                    "Загрузите его в редакторе шаблонов: Данные -> Редактор шаблонов");
            }

            string localTemplateMd5 = null;
            if (File.Exists(IssueTemplatePath))
            {
                localTemplateMd5 = Md5Helper.GetMd5Hash(File.ReadAllBytes(IssueTemplatePath));
            }

            if (!File.Exists(IssueTemplatePath) || localTemplateMd5 != issueTemplate.HashMd5)
            {
                issueTemplate = _templateRepository.GetActualTemplate(TemplateTypeId.InformationIssueTemplate, true);
                ByteArrayToFile(IssueTemplatePath, issueTemplate.FileData);
            }
        }

        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }

    public interface ITemplateService
    {
        string IssueTemplatePath { get; }
        List<TemplateType> AvailableTemplates { get; }

        void LoadActualIssueTemplate();
    }
}
