using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DataVenderSmsSignStatusGetRequest : JdRequestBase<DataVenderSmsSignStatusGetResponse>
    {
                                                                                                                                                    public  		Nullable<int>
              channel
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.data.vender.sms.sign.status.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("channel", this.            channel
);
                                                    }
    }
}





        
 

