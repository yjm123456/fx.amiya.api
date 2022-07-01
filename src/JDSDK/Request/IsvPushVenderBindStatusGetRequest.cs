using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvPushVenderBindStatusGetRequest : JdRequestBase<IsvPushVenderBindStatusGetResponse>
    {
                                                                                  public  		string
              bindAppCode
 {get; set;}
                                                          
                                                          public  		string
              dbId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              bindUserId
 {get; set;}
                                                          
                                                          public  		string
              pageNo
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.isv.push.vender.bind.status.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("bindAppCode", this.            bindAppCode
);
                                                                                                        parameters.Add("dbId", this.            dbId
);
                                                                                                        parameters.Add("bindUserId", this.            bindUserId
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

