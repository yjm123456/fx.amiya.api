using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DentistryPushGoodsInfoRequest : JdRequestBase<DentistryPushGoodsInfoResponse>
    {
                                                                                                                                              public  		string
              goodsId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              channelType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  itemName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  itemDesc {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
              goodsSuitable
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              goodsPrice
 {get; set;}
                                                          
                                                          public  		string
              goodsFeature
 {get; set;}
                                                          
                                                          public  		string
              goodsName
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dentistry.pushGoodsInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goodsId", this.            goodsId
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                                                                                                        parameters.Add("itemName", this.            itemName
);
                                                                                                        parameters.Add("itemDesc", this.            itemDesc
);
                                                                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("goodsSuitable", this.            goodsSuitable
);
                                                                                                        parameters.Add("goodsPrice", this.            goodsPrice
);
                                                                                                        parameters.Add("goodsFeature", this.            goodsFeature
);
                                                                                                        parameters.Add("goodsName", this.            goodsName
);
                                                                                                                            }
    }
}





        
 

