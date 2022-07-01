using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsSoaCompensateQueryCompensateListRequest : JdRequestBase<PopAfsSoaCompensateQueryCompensateListResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              compensateId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              refId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              refType
 {get; set;}
                                                          
                                                          public  		string
              modifiedStartTime
 {get; set;}
                                                          
                                                          public  		string
              modifiedEndTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.afs.soa.compensate.queryCompensateList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("compensateId", this.            compensateId
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("refId", this.            refId
);
                                                                                                        parameters.Add("refType", this.            refType
);
                                                                                                        parameters.Add("modifiedStartTime", this.            modifiedStartTime
);
                                                                                                        parameters.Add("modifiedEndTime", this.            modifiedEndTime
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

