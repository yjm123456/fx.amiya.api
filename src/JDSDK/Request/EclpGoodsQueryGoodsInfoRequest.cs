using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpGoodsQueryGoodsInfoRequest : JdRequestBase<EclpGoodsQueryGoodsInfoResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              isvGoodsNos
 {get; set;}
                                                          
                                                          public  		string
              goodsNos
 {get; set;}
                                                          
                                                          public  		string
              queryType
 {get; set;}
                                                          
                                                          public  		string
              barcodes
 {get; set;}
                                                          
                                                          public  		string
              pageNo
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.goods.queryGoodsInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("isvGoodsNos", this.            isvGoodsNos
);
                                                                                                        parameters.Add("goodsNos", this.            goodsNos
);
                                                                                                        parameters.Add("queryType", this.            queryType
);
                                                                                                        parameters.Add("barcodes", this.            barcodes
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

