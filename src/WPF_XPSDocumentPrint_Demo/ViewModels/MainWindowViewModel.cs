using Prism.Mvvm;

using System.Windows.Controls;
using System.Windows.Documents;
using System;
using System.Windows;
using System.Windows.Threading;
using System.IO.Packaging;
using System.IO;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Threading;
using Prism.Commands;
using System.Windows.Markup;
using WPF_XPSDocumentPrint_Demo.Attributes;
using System.Linq;
using WPF_XPSDocumentPrint_Demo.Models;

namespace WPF_XPSDocumentPrint_Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private FixedDocumentSequence _StudentDocument;
        /// <summary>
        /// 模板文档（绑定至前端要显示的文档视图中）
        /// </summary>
        public FixedDocumentSequence StudentDocument
        {
            get { return _StudentDocument; }
            set { _StudentDocument = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<bool?> ChangeDocCommand { get; set; }


        private delegate void LoadXpsMethod();
        private MemoryStream ms;
        private Package package;
        private Uri DocumentUri;

        public MainWindowViewModel()
        {
            ChangeDocCommand = new DelegateCommand<bool?>(b => ChangeDoc(b));
        }

        private void ChangeDoc(bool? isChecked)
        {
            FlowDocument doc = null;
            if (isChecked==false)
            {
                doc = FillFlowDocument<Student>(new Student
                {
                    Name = "Test1",
                    Class = "Test1",
                    Chinese = 99,
                    Math = 59,
                    English = 66,
                    Comments = "Test1"
                });
                Application.Current.Dispatcher.InvokeAsync(()=>FillDocumentViewer(doc), DispatcherPriority.ApplicationIdle);
            }
            else if(isChecked==true)
            {

                doc = FillFlowDocument<PrintTemplate1>(new PrintTemplate1
                {
                    Name = "Test2",
                    Class = "Test2",
                    Chinese = 99,
                    Math = 59,
                    English = 66,
                    Comments = "Test2"
                });
                Application.Current.Dispatcher.InvokeAsync(() => FillDocumentViewer(doc), DispatcherPriority.ApplicationIdle);
            }
            
        }

        private void FillDocumentViewer(FlowDocument doc)
        {
            try
            {
                ms = new MemoryStream();
                package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
                DocumentUri = new Uri("pack://InMemoryDocument.xps");
                if (PackageStore.GetPackage(DocumentUri) == null)
                {
                    PackageStore.AddPackage(DocumentUri, package);
                }
                XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                writer.Write(((IDocumentPaginatorSource)doc).DocumentPaginator);
                StudentDocument = xpsDocument.GetFixedDocumentSequence();
                xpsDocument.Close();
                Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("读取打印模板错误：{0}", e.ToString());
            }
        }

        private FlowDocument FillFlowDocument<T>(T data)
        {
            var type = data.GetType();
            var att = Attribute.GetCustomAttributes(type, typeof(PrintAttribute)).FirstOrDefault();

            if (att != null)
            {
                var attName = ((PrintAttribute)att).GetName();
                var doc = (FlowDocument)Application.LoadComponent(new Uri($"/WPF_XPSDocumentPrint_Demo;component/Resources/{attName}", UriKind.RelativeOrAbsolute));
                doc.DataContext = data;

                return doc;
            }
            else
            {
                return new FlowDocument();
            }
        }

        public void Dispose()
        {
            PackageStore.RemovePackage(DocumentUri);
            if (package != null)
            {
                package.Close();
                package = null;
            }
            if (ms != null)
            {
                ms.Close();
                ms = null;
            }
            DocumentUri = null;
        }
    }
}
