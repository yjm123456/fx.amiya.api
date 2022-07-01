using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitDmpBatchBindCrowdRefRequest : JdRequestBase<DspAdunitDmpBatchBindCrowdRefResponse>
    {
                                                                                                                   public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              adGroupType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              opt
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  crowdId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isUsed {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  adGroupPrice {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.dsp.adunit.dmp.batchBindCrowdRef";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("adGroupType", this.            adGroupType
);
                                                                                                        parameters.Add("opt", this.            opt
);
                                                                                                                                                                                        parameters.Add("crowdId", this.            crowdId
);
                                                                                                        parameters.Add("isUsed", this.            isUsed
);
                                                                                                        parameters.Add("adGroupPrice", this.            adGroupPrice
);
                                                                                                                                                    }
    }
}





        
 

