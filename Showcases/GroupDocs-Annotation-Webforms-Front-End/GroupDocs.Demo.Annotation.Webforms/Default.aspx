<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Demo.Annotation.Webforms.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GroupDocs.Annotation: WebForms - Front-End Application</title>

    <%-- *** By Executing AnnotationScripts will render all required JS and CSS from server side along with calling initial JS methods. ***--%>
    <%=GroupDocs.Demo.Annotation.Webforms.HtmlHelperExtensions.AnnotationScripts() %>

    <%-- *** You can also use this as another option to render scripts from specific path as you required, please must comment AnnotationScripts line if using this. ***--%>
    <%--<script type='text/javascript' src='/Scripts/libs/jquery-1.9.1.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/jquery-ui-1.10.3.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/knockout-3.2.0.js'></script>
    <script type='text/javascript' src='/Scripts/libs/turn.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/modernizr.2.6.2.Transform2d.min.js'></script>
    <script type='text/javascript' src='/Scripts/installableViewer.js'></script>
    <script type='text/javascript'>$.ui.groupdocsViewer.prototype.applicationPath = '/Default.aspx';</script>
    <script type='text/javascript'>    $.ui.groupdocsViewer.prototype.useHttpHandlers = false;</script>
    <script type='text/javascript' src='/Scripts/libs/GroupdocsViewer.all.js'></script>
    <script type='text/javascript' src='/Scripts/libs/jquery.signalR-1.1.2.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/jquery.tinyscrollbar.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/jquery.custom-scrollbar.js'></script>
    <script type='text/javascript' src='/Scripts/libs/jquery.ui.touch-punch.min.js'></script>
    <script type='text/javascript' src='/Scripts/libs/mousetrap.js'></script>
    <script type='text/javascript' src='/Scripts/RaphaelJS/raphael-min.js'></script>
    <script type='text/javascript' src='/Scripts/jGroupDocs.Undo.js'></script>
    <script type='text/javascript' src='/Scripts/jGroupDocs.Utils.js'></script>
    <script type='text/javascript' src='/Scripts/jGroupDocs.Printable.js'></script>
    <script type='text/javascript' src='/Scripts/libs/bootstrap.min.js'></script>
    <script type='text/javascript' src='/Scripts/AnnotationService.js'></script>
    <script type='text/javascript' src='/Scripts/AnnotationCommands.js'></script>
    <script type='text/javascript' src='/Scripts/Annotation2Legacy.js'></script>
    <script type='text/javascript' src='/Scripts/AreaAnnotation.js'></script>
    <script type='text/javascript' src='/Scripts/PointAnnotation.js'></script>
    <script type='text/javascript' src='/Scripts/TextStrikeout.js'></script>
    <script type='text/javascript' src='/Scripts/PolylineAnnotation.js'></script>
    <script type='text/javascript' src='/Scripts/TextStrikeout.js'></script>
    <script type='text/javascript' src='/Scripts/TextField.js'></script>
    <script type='text/javascript' src='/Scripts/Watermark.js'></script>
    <script type='text/javascript' src='/Scripts/TextReplacement.js'></script>
    <script type='text/javascript' src='/Scripts/TextRedaction.js'></script>
    <script type='text/javascript' src='/Scripts/GraphicsAnnotation.js'></script>
    <script type='text/javascript' src='/Scripts/MeasurementAnnotation.js'></script>
    <script type='text/javascript' src='/Scripts/AnnotationWidget.js'></script>
    <script type='text/javascript' src='/Scripts/AnnotationInitControls.js'></script>
    <link rel="stylesheet" type="text/css" href="/CSS/Annotation.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/Annotation.Toolbox.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/groupdocsViewer.all.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/groupdocsViewer.all.css" />
    <link rel="stylesheet" type="text/css" href="/CSS/jquery-ui-1.10.3.dialog.min.css" />
    <script type='text/javascript'>
        var container = window.Container || new JsInject.Container();
        container.Register('PathProvider', function (c) { return jSaaspose.utils; }, true);
        window.Container = container;
    </script>--%>

    <%-- *** By Executing Annotation() will render all required JS and options from server side along with calling initial JS methods. ***--%>
    <%--    <%=GroupDocs.Demo.Annotation.Webforms.HtmlHelperExtensions.Annotation()
    .ElementId("annotation-widget")
    .FilePath("Quick_Start_Guide_To_Using_GroupDocs.pdf")
    .ShowZoom(true)
    .ShowPaging(true)
    .ShowThumbnails(true)
    .OpenThumbnails(false)
    .PreloadPageCount(3)
    .EnableRightClickMenu(true)
    .ShowFileExplorer(true)
    .Tools(GroupDocs.Demo.Annotation.Webforms.BusinessLogic.Options.AnnotationTools.All)
    .ShowHeader(true)

    .ClickableAnnotations(true)
    .ShowFileExplorer(true)
    .AccessRights(GroupDocs.Annotation.Domain.AnnotationReviewerRights.All) %>--%>

    <%-- *** Default: You can also use this as another option to call annotation with js options as you required (its faster than above as it execute directly without getting response from server before js execution, please must comment above Annotation() script lines if using this. ***--%>
    <script type="text/javascript">
        $(function () {
            var annotationWidget = $('#annotation-widget').groupdocsAnnotation({
                localizedStrings: null, width: 0,
                height: 0,
                fileId: 'Quick_Start_Guide_To_Using_GroupDocs.pdf',
                docViewerId: 'annotation-widget-doc-viewer',
                quality: 90,
                enableRightClickMenu: true,
                showHeader: true,
                showZoom: true,
                showPaging: true,
                showFileExplorer: true,
                showThumbnails: true,
                showToolbar: true,
                openThumbnails: false,
                zoomToFitWidth: false,
                zoomToFitHeight: false,
                initialZoom: 100,
                preloadPagesCount: 3,
                enableSidePanel: true,
                scrollOnFocus: true,
                enabledTools: 8191,
                connectorPosition: 0,
                saveReplyOnFocusLoss: false,
                clickableAnnotations: true,
                disconnectUncommented: false,
                enableStandardErrorHandling: true,
                undoEnabled: true,
                anyToolSelection: true,
                tabNavigationEnabled: false,
                tooltipsEnabled: true,
                textSelectionEnabled: false,
                textSelectionByCharModeEnabled: false,
                toolDeactivationMode: 0,
                sideboarContainerSelector: 'div.comments_sidebar_wrapper',
                usePageNumberInUrlHash: false,
                textSelectionSynchronousCalculation: true,
                variableHeightPageSupport: true,
                useJavaScriptDocumentDescription: true,
                isRightPanelEnabled: true,
                createMarkup: true,
                use_pdf: 'true',
                _mode: 'annotatedDocument',
                selectionContainerSelector: "[name='selection-content']",

                graphicsContainerSelector: '.annotationsContainer',

                searchForSeparateWords: false,
                userName: 'GroupDocs@GroupDocs.com', userId: '52ced024-26e0-4b59-a510-ca8f5368e315'

            });
        });
    </script>

</head>

<body>
    <%-- *** 'annotation-widget' div will be populated and rendered with html for Viewer and Annotation tools & features provided by GroupDocs.Annotation for .NET API for .NET *** --%>
    <div id="annotation-widget" class="GroupDocs_viewer_wrapper grpdx" style="width: 100%; height: 100%;">
    </div>

</body>
</html>
