using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VssPromotionQueryunitpromopagelistRequest : JdRequestBase<VssPromotionQueryunitpromopagelistResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      promoName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                                                      createTimeBegin
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      createTimeEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      promoState
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      auditState
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vss.promotion.queryunitpromopagelist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                        parameters.Add("promo_name", this.                                                                                    promoName
);
                                                                                                        parameters.Add("create_time_begin", this.                                                                                                                    createTimeBegin
);
                                                                                                        parameters.Add("create_time_end", this.                                                                                                                    createTimeEnd
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("promo_state", this.                                                                                    promoState
);
                                                                                                        parameters.Add("audit_state", this.                                                                                    auditState
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                            }
    }
}





        
 

