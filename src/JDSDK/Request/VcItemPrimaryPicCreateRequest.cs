using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemPrimaryPicCreateRequest : JdRequestBase<VcItemPrimaryPicCreateResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  imageList {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  skuIdLong {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  imageListLong {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  skuIdLucency {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  imageListLucency {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
                                                                                      isPublishSchedule
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      publishTime
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.vc.item.primaryPic.create";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("image_list", this.                                                                                    imageList
);
                                                                                                                                                                                                                                        parameters.Add("sku_id_long", this.                                                                                                                    skuIdLong
);
                                                                                                        parameters.Add("image_list_long", this.                                                                                                                    imageListLong
);
                                                                                                                                                                                                                                        parameters.Add("sku_id_lucency", this.                                                                                                                    skuIdLucency
);
                                                                                                        parameters.Add("image_list_lucency", this.                                                                                                                    imageListLucency
);
                                                                                                                                                        parameters.Add("is_publishSchedule", this.                                                                                    isPublishSchedule
);
                                                                                                        parameters.Add("publish_time", this.                                                                                    publishTime
);
                                                                                                                            }
    }
}





        
 

