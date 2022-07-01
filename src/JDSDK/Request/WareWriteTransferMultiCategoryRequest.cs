using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareWriteTransferMultiCategoryRequest : JdRequestBase<WareWriteTransferMultiCategoryResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              multiCategoryId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ware.write.transferMultiCategory";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("multiCategoryId", this.            multiCategoryId
);
                                                    }
    }
}





        
 

