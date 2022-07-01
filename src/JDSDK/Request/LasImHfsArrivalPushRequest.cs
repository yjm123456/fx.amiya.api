using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasImHfsArrivalPushRequest : JdRequestBase<LasImHfsArrivalPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      opeN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      serProNo
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                      opeT
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      proNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      proN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      citNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      citN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      couNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      couN
 {get; set;}
                                                                                                                                  
                                                          public  		string
              add1
 {get; set;}
                                                          
                                                          public  		string
                                                                                      poiN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      conTel
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      conN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      colCod
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      serNos
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.las.im.hfs.arrival.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("ope_n", this.                                                                                    opeN
);
                                                                                                        parameters.Add("ser_pro_no", this.                                                                                                                    serProNo
);
                                                                                                        parameters.Add("ope_t", this.                                                                                    opeT
);
                                                                                                        parameters.Add("pro_no", this.                                                                                    proNo
);
                                                                                                        parameters.Add("pro_n", this.                                                                                    proN
);
                                                                                                        parameters.Add("cit_no", this.                                                                                    citNo
);
                                                                                                        parameters.Add("cit_n", this.                                                                                    citN
);
                                                                                                        parameters.Add("cou_no", this.                                                                                    couNo
);
                                                                                                        parameters.Add("cou_n", this.                                                                                    couN
);
                                                                                                        parameters.Add("add", this.            add1
);
                                                                                                        parameters.Add("poi_n", this.                                                                                    poiN
);
                                                                                                        parameters.Add("con_tel", this.                                                                                    conTel
);
                                                                                                        parameters.Add("con_n", this.                                                                                    conN
);
                                                                                                        parameters.Add("col_cod", this.                                                                                    colCod
);
                                                                                                        parameters.Add("ser_nos", this.                                                                                    serNos
);
                                                                            }
    }
}





        
 

