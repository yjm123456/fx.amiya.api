using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitAdgroupListRequest : JdRequestBase<DspAdkcunitAdgroupListResponse>
    {
                                                                                                                   public  		string
              pageNum
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.adgroup.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                    }
    }
}





        
 

