using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopJmGetUserBaseInfoByPinRequest : JdRequestBase<PopJmGetUserBaseInfoByPinResponse>
    {
                                                                                  public  		string
              pin
 {get; set;}
                                                          
                                                          public  		string
              loadType
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.jm.getUserBaseInfoByPin";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("pin", this.            pin
);
                                                                                                        parameters.Add("loadType", this.            loadType
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                    }
    }
}





        
 

