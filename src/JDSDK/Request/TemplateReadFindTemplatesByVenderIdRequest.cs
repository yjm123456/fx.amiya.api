using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TemplateReadFindTemplatesByVenderIdRequest : JdRequestBase<TemplateReadFindTemplatesByVenderIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                                                                                       public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.template.read.findTemplatesByVenderId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("pageNo", this.            pageNo
);
                                                                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

