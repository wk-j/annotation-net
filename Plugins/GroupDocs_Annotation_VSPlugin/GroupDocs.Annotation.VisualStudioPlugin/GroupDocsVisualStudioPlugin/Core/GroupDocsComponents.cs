// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsAnnotationVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsAnnotation = new GroupDocsComponent();
            groupdocsAnnotation.set_downloadUrl("");
            groupdocsAnnotation.set_downloadFileName("groupdocs.Annotation.zip");
            groupdocsAnnotation.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsAnnotation.set_remoteExamplesRepository("https://github.com/groupdocs-annotation/GroupDocs.Annotation-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsAnnotation);
        }
    }
}
