using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpArticleSaveRequest : JdRequestBase<CmpArticleSaveResponse>
    {
                                                                                                                                              public  		string
              summary
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              saveType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              publishTime
 {get; set;}
                                                          
                                                                                           public  		string
              dpContent
 {get; set;}
                                                          
                                                          public  		string
              skuStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessId
 {get; set;}
                                                          
                                                          public  		string
              threeDskuStr
 {get; set;}
                                                          
                                                          public  		string
              threeDimensionalImgInfo
 {get; set;}
                                                          
                                                          public  		string
              title
 {get; set;}
                                                          
                                                          public  		string
              titlePicUrl
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              support3d
 {get; set;}
                                                          
                                                          public  		string
              labelIds
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              articleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.article.save";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("summary", this.            summary
);
                                                                                                        parameters.Add("saveType", this.            saveType
);
                                                                                                        parameters.Add("publishTime", this.            publishTime
);
                                                                                                                                                        parameters.Add("dpContent", this.            dpContent
);
                                                                                                        parameters.Add("skuStr", this.            skuStr
);
                                                                                                        parameters.Add("businessId", this.            businessId
);
                                                                                                        parameters.Add("threeDskuStr", this.            threeDskuStr
);
                                                                                                        parameters.Add("threeDimensionalImgInfo", this.            threeDimensionalImgInfo
);
                                                                                                        parameters.Add("title", this.            title
);
                                                                                                        parameters.Add("titlePicUrl", this.            titlePicUrl
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                        parameters.Add("support3d", this.            support3d
);
                                                                                                        parameters.Add("labelIds", this.            labelIds
);
                                                                                                        parameters.Add("articleType", this.            articleType
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                            }
    }
}





        
 

