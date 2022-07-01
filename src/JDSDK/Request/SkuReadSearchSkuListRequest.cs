using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SkuReadSearchSkuListRequest : JdRequestBase<SkuReadSearchSkuListResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  wareId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  skuStatuValue {get; set; }
                                                                                                                                                                                                public  		Nullable<long>
              maxStockNum
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              minStockNum
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endCreatedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endModifiedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startCreatedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startModifiedTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  outId {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              colType
 {get; set;}
                                                          
                                                          public  		string
              itemNum
 {get; set;}
                                                          
                                                          public  		string
              wareTitle
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  orderFiled {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderType {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                                                                                       public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.sku.read.searchSkuList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                                                                                        parameters.Add("skuStatuValue", this.            skuStatuValue
);
                                                                                                                                parameters.Add("maxStockNum", this.            maxStockNum
);
                                                                                                        parameters.Add("minStockNum", this.            minStockNum
);
                                                                                                        parameters.Add("endCreatedTime", this.            endCreatedTime
);
                                                                                                        parameters.Add("endModifiedTime", this.            endModifiedTime
);
                                                                                                        parameters.Add("startCreatedTime", this.            startCreatedTime
);
                                                                                                        parameters.Add("startModifiedTime", this.            startModifiedTime
);
                                                                                                                                                parameters.Add("outId", this.            outId
);
                                                                                                                                parameters.Add("colType", this.            colType
);
                                                                                                        parameters.Add("itemNum", this.            itemNum
);
                                                                                                        parameters.Add("wareTitle", this.            wareTitle
);
                                                                                                                                                                                        parameters.Add("orderFiled", this.            orderFiled
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                                                parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

