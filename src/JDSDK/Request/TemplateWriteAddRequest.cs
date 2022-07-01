using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TemplateWriteAddRequest : JdRequestBase<TemplateWriteAddResponse>
    {
                                                                                                                                                                                                                                                                                                                                              public  		string
              bottomContent
 {get; set;}
                                                          
                                                          public  		string
              headContent
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
                get{return "jingdong.template.write.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("bottomContent", this.            bottomContent
);
                                                                                                        parameters.Add("headContent", this.            headContent
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





        
 

