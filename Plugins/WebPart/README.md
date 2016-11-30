# GroupDocs.Annotation SharePoint Web-Part

Using GroupDocs.Annotation SharePoint WebPart, SharePoint developers can not only explore and investigate GroupDocs.Annotation for .NET Front End but can also customize this Web-Part according to their needs

# Features

The SharePoint Web-Part Front End provides end users with tools needed for convenient annotating, viewing and navigation of a documents in a browser. The front end provides all the most commonly used UI controls available in native Adobe Reader’s plugin, including:

* Apply Annotations.
* Add/Delete comments.
* Thumbnail images for Annotation.
* Import Annotation.
* Page Zoom-in and Zoom-Out
* File Browser.
* Download As PDF
* Image Representation of the document
* Scroll view, one page in a row, two pages in a row view, double page flipping
* Pagination controls
* Text selection and copying to the clipboard

# SharePoint Web-Part Requirements

* SharePoint Server 2013
* Visual Studio 2010 or above
* Windows server 2008 or above
* Any standard web-browser, including IE8+, Mozilla Firefox, Chrome, Opera, Safari5

# How to Run Plugin

* Download GroupDocs.Annotation SharePoint Web-Part from GitHub
* Open GroupDocs.Annotation SharePoint Web-Part in your visual studio
* Open project properties, set your Site URL
* Set your license path in Default.aspx.cs
* Open Global.asax from your VirtualDirectories root path: C:\Inetpub\Wwwroot\Wss\VirtualDirectories\porthost
* Add following code in your Global.asax

```
<%@ Assembly Name="GroupDocs_Annotation_SharePoint_WebPart, Version=1.0.0.0,
Culture=neutral, PublicKeyToken=46f3db1189e89af3"%>
<%@ Import Namespace="GroupDocs_Annotation_SharePoint_WebPart" %>
<%@ Application Language="C#" Inherits="GroupDocs_Annotation_SharePoint_WebPart.Global" %>

```

* Add following Http Module in web.config in your VirtualDirectories root path.

```
 <httpModules>
      <add name="Session" type="System.Web.SessionState.SessionStateModule" />
 </httpModules>

```
* Click Run in Visual Studio.

