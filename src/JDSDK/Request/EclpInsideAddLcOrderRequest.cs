using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpInsideAddLcOrderRequest : JdRequestBase<EclpInsideAddLcOrderResponse>
    {
                                                                                                                                              public  		string
              sellerLcNo
 {get; set;}
                                                          
                                                          public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		string
              wareHouseNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              outsideLogicStock
 {get; set;}
                                                          
                                                          public  		string
              insideLogicStock
 {get; set;}
                                                          
                                                          public  		string
              lack
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  orderLine {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  outGoodsLevel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  inGoodsLevel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planQty {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.inside.addLcOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sellerLcNo", this.            sellerLcNo
);
                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("wareHouseNo", this.            wareHouseNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("outsideLogicStock", this.            outsideLogicStock
);
                                                                                                        parameters.Add("insideLogicStock", this.            insideLogicStock
);
                                                                                                        parameters.Add("lack", this.            lack
);
                                                                                                                                                                                                                parameters.Add("orderLine", this.            orderLine
);
                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("outGoodsLevel", this.            outGoodsLevel
);
                                                                                                        parameters.Add("inGoodsLevel", this.            inGoodsLevel
);
                                                                                                        parameters.Add("planQty", this.            planQty
);
                                                                                                                                                    }
    }
}





        
 

