using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewWareMobilebigfieldGetRequest : JdRequestBase<NewWareMobilebigfieldGetResponse>
    {
                                                                                  public  		Nullable<long>
              skuid
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.new.ware.mobilebigfield.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuid", this.            skuid
);
                                                    }
    }
}





        
 

