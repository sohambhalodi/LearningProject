File Management in SharePoint
Follow the given steps to manage file in SharePoint Using .net

Setup the Microsoft 365.
Generate Tenant, to generate that follow the steps or checkout the Video.
1.	Join the Microsoft Dev Program 
a.	https://developer.microsoft.com/en-us/microsoft-365/dev-program
2.	Goto the admin SharePoint from the left pane(click all then it will be visible)
3.	Goto Sites >> Active Sites
4.	Click Create >> Select Team Site from the Popup >> add name of site and select site owner

Video: https://youtu.be/ijaJgc3J-iE?list=PLR9nK3mnD-OXvSWvS2zglCzz4iplhVrKq
For article: https://learn.microsoft.com/en-us/sharepoint/dev/spfx/set-up-your-developer-tenant#create-app-catalog-site 

Generate App in Azure

1.	Then After go to Azure Portal 
a.	https://entra.microsoft.com/#view/Microsoft_AAD_IAM/EntraHome.ReactView
2.	Goto Active Directory
3.	Goto Applications in left Pane 
4.	App registrations >> Click on New Registration 
5.	Add Name, Select Account Type 3(both Multitenant and personal account)
 
6.	Add redirection URL (for demo add localhost:[Portno])
7.	Open the app and copy the client ID(app Id) (will use in code for api call)
 
Set API & add Required Permission
1.	Goto API Permission 
2.	Click Add a Permission >> in popup Select Share Point
3.	Click Delegated Permissions
4.	Click AllSites >> Check AllSites.FullControl
5.	Then click on MyFiles >> Check MyFiles.read & MyFiles.Write 
6.	Click Add Permission.
7.	Click Grant admin Consent for MSFT if require.

Code Guidance 

Add package like 

 

to Generate Token for accessing API (Microsoft graph API)
https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/using-csom-for-dotnet-standard#using-modern-authentication-with-csom-for-net-standard:~:text=using%20Microsoft.SharePoint,SuppressFinalize(this)%3B%0A%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%7D%0A%7D

Link for code demo: https://stackoverflow.com/questions/63722714/how-can-i-upload-a-file-into-sharepoint-library-in-asp-net-mvc


Link for code to get list of files
https://learn.microsoft.com/en-us/answers/questions/845349/how-to-list-files-in-shared-documents

https://learn.microsoft.com/en-us/answers/questions/1200390/c-to-retrieve-document-library-files-and-folders-f#:~:text=string%20siteUrl%20%3D%20%22https,DateTime)item%5B%22Modified%22%5D%3B%0A%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%7D%0A%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%7D


