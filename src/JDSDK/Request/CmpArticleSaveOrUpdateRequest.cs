using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpArticleSaveOrUpdateRequest : JdRequestBase<CmpArticleSaveOrUpdateResponse>
    {
                                                                                                                                              public  		string
              summary
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              houseArea
 {get; set;}
                                                          
                                                          public  		string
              labelIds
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              houseBudget
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              submitTime
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              skuList
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              saveType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              id
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                          public  		string
              districtName
 {get; set;}
                                                          
                                                          public  		string
              title
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              districtId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              source
 {get; set;}
                                                          
                                                                                           public  		string
              titlePicUrl
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              articleType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.article.saveOrUpdate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("summary", this.            summary
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("houseArea", this.            houseArea
);
                                                                                                        parameters.Add("labelIds", this.            labelIds
);
                                                                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("houseBudget", this.            houseBudget
);
                                                                                                        parameters.Add("submitTime", this.            submitTime
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("skuList", this.            skuList
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("saveType", this.            saveType
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                        parameters.Add("districtName", this.            districtName
);
                                                                                                        parameters.Add("title", this.            title
);
                                                                                                        parameters.Add("districtId", this.            districtId
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                                                        parameters.Add("titlePicUrl", this.            titlePicUrl
);
                                                                                                                                                        parameters.Add("articleType", this.            articleType
);
                                                                            }
    }
}





        
 

