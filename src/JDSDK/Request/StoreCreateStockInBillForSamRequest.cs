using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreCreateStockInBillForSamRequest : JdRequestBase<StoreCreateStockInBillForSamResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
                                                                                                                      samBillId
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              arrivalDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      clubId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  itemId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  remark {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              samStoreType
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.store.createStockInBillForSam";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("sam_bill_id", this.                                                                                                                    samBillId
);
                                                                                                        parameters.Add("arrivalDay", this.            arrivalDay
);
                                                                                                        parameters.Add("club_id", this.                                                                                    clubId
);
                                                                                                                                                                                        parameters.Add("item_id", this.                                                                                    itemId
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                                                        parameters.Add("samStoreType", this.            samStoreType
);
                                                                                                                            }
    }
}





        
 

