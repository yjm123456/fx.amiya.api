using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TemplateWriteUpdateRequest : JdRequestBase<TemplateWriteUpdateResponse>
    {
                                                                                                                                                                                                                                                                                                                                              public  		string
              bottomContent
 {get; set;}
                                                          
                                                          public  		string
              headContent
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                                                           public  		string
              mobileBottomContent
 {get; set;}
                                                          
                                                          public  		string
              mobileHeadContent
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.template.write.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("bottomContent", this.            bottomContent
);
                                                                                                        parameters.Add("headContent", this.            headContent
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                                                                        parameters.Add("mobileBottomContent", this.            mobileBottomContent
);
                                                                                                        parameters.Add("mobileHeadContent", this.            mobileHeadContent
);
                                                                            }
    }
}





        
 

