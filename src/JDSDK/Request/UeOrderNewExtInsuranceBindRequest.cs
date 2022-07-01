using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewExtInsuranceBindRequest : JdRequestBase<UeOrderNewExtInsuranceBindResponse>
    {
                                                                                                                                              public  		Nullable<int>
              bindStat
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  orderNos {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ue.order.new.extInsuranceBind";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("bindStat", this.            bindStat
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                                                                        parameters.Add("orderNos", this.            orderNos
);
                                                                            }
    }
}





        
 

