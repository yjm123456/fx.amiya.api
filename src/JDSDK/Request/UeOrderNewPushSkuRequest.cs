using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewPushSkuRequest : JdRequestBase<UeOrderNewPushSkuResponse>
    {
                                                                                                                                              public  		Nullable<int>
              stat
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  sku {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ue.order.new.pushSku";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("stat", this.            stat
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                            }
    }
}





        
 

