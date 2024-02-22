using Microsoft.AspNetCore.Mvc;
using Microsoft.SharePoint.Client;
using SharePointFileUpload.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

namespace SharePointFileUpload.Controllers
{
    public class HomeController : Controller
    {
        #region Default Code
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Secure Password Generate
        private SecureString ConvertToSecureString(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach (char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }
        #endregion

        #region Unused Code
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        public IActionResult Index()
        {
            //TODO: Need to do dynamic to reduce duplicate code 
            Uri Path = new Uri("https://3c12sy.sharepoint.com/sites/dev");
            string strUserName = "Manthan@3c12sy.onmicrosoft.com";
            SecureString strPassword = ConvertToSecureString("Rudransh02@#1998");

            AuthManager objAuth = new AuthManager();

            ClientContext objCtx = objAuth.GetContext(Path, strUserName, strPassword);
            GenerateFolder(objCtx);
            UploadFileinFolder(objCtx);

            return View();
        }

        #region Generate Folder in Sharepoint
        public void GenerateFolder(ClientContext ctx)
        {
            Web web = ctx.Web;
            ctx.Load(web);
            ctx.ExecuteQuery();

            List byTitle = ctx.Web.Lists.GetByTitle("TestLibrary");

            FolderCollection folders = byTitle.RootFolder.Folders;

            ctx.Load(folders, fl => fl.Include(ct => ct.Name)
            .Where(ct => ct.Name == "NewFolderTest"));

            ctx.ExecuteQuery();
            bool IsFolderExists = folders.Any();

            if (!IsFolderExists)
            {
                ListItemCreationInformation listItemCreationInformation = new ListItemCreationInformation();
                listItemCreationInformation.UnderlyingObjectType = FileSystemObjectType.Folder;
                listItemCreationInformation.LeafName = "NewFolderTest";

                ListItem listItem = byTitle.AddItem(listItemCreationInformation);
                listItem["Title"] = "NewFolderTest";
                listItem.Update();

                ctx.ExecuteQuery();
            }
        }
        #endregion

        #region Upload File in SharePoint
        public void UploadFileinFolder(ClientContext ctx)
        {
            try
            {
                Web web = ctx.Web;
                ctx.Load(web);
                ctx.ExecuteQuery();

                FileCreationInformation newFile = new FileCreationInformation();
                newFile.Content = System.IO.File.ReadAllBytes(@"D:\Demo\SharePointDemo\Docs\TextDocforTesting.txt");
                newFile.Url = @"TextDocforTesting.txt";

                List byTitle = ctx.Web.Lists.GetByTitle("TestLibrary");
                Folder folder = byTitle.RootFolder.Folders.GetByUrl("NewFolderTest");
                ctx.Load(folder);
                ctx.ExecuteQuery();

                FileCollection fcFiles = folder.Files;

                ctx.Load(fcFiles, fl => fl.Include(ct => ct.Name)
                .Where(ct => ct.Name == "TextDocforTesting.txt"));

                ctx.ExecuteQuery();
                bool IsFileExists = fcFiles.Any();

                if (!IsFileExists)
                {
                    Microsoft.SharePoint.Client.File uploadFile = folder.Files.Add(newFile);
                    uploadFile.CheckIn("checkin", CheckinType.MajorCheckIn);
                    ctx.Load(byTitle);
                    ctx.Load(uploadFile);

                    ctx.ExecuteQuery();
                    Console.WriteLine("done");
                }
                else
                    Console.WriteLine("File Exists");
            }
            catch (Exception ex) { }
        }
        #endregion

        public IActionResult GetListofDocs()
        {
            List<mdlDocs> lstFile = new List<mdlDocs>();

            //TODO: Need to do dynamic to reduce duplicate code 
            Uri Path = new Uri("https://3c12sy.sharepoint.com/sites/dev");
            string strUserName = "Manthan@3c12sy.onmicrosoft.com";
            SecureString strPassword = ConvertToSecureString("Rudransh02@#1998");

            AuthManager objAuth = new AuthManager();
            ClientContext objCtx = objAuth.GetContext(Path, strUserName, strPassword);

            List list = objCtx.Web.Lists.GetByTitle("TestLibrary");
            objCtx.Load(list);
            objCtx.Load(list.RootFolder);
            objCtx.Load(list.RootFolder.Folders);
            objCtx.Load(list.RootFolder.Files);
            objCtx.ExecuteQuery();
            FolderCollection fcol = list.RootFolder.Folders;
            FileCollection fcl = list.RootFolder.Files;
            foreach (Folder f in fcol)
            {
                lstFile.Add(new mdlDocs() { strFolderName = f.Name });

                //TODO: Use treeview to show all files under perticular folder.
                //objCtx.Load(f.Files);
                //objCtx.ExecuteQuery();
                //FileCollection fileCol = f.Files;
                //foreach (Microsoft.SharePoint.Client.File file in fileCol)
                //{    
                //}
            }
            foreach (Microsoft.SharePoint.Client.File f in fcl)
            {
                lstFile.Add(new mdlDocs() { strFolderName = f.Name });
            }



            return View(lstFile);
        }
    }
}