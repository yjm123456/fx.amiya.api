using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bMessageGetRequest : JdRequestBase<B2bMessageGetResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  typeId {get; set; }
                                                                                                                                                                                                                                                     public override string ApiName
            {
                get{return "jingdong.b2b.message.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("typeId", this.            typeId
);
                                                                                                                                                                                                    }
    }
}





        
 

