using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bWareQueryUserToPoolRequest : JdRequestBase<B2bWareQueryUserToPoolResponse>
    {
                                                                                                                                              public  		string
              businessChannel
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              mappingId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endModifyTime
 {get; set;}
                                                          
                                                          public  		string
              userToPoolSortField
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startCreateTime
 {get; set;}
                                                          
                                                          public  		string
              attributeId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              mappingLevel
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startModifyTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              b2bMappingId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cateType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              wareMappingType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		string
              bizPoolType
 {get; set;}
                                                          
                                                          public  		string
              b2bUserToPoolQueryTypeEnum
 {get; set;}
                                                          
                                                          public  		string
              editor
 {get; set;}
                                                          
                                                          public  		string
              creator
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalItem
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalPage
 {get; set;}
                                                          
                                                          public  		string
              sortTypeEnum
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              b2bPoolId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endCreateTime
 {get; set;}
                                                          
                                                          public  		string
              b2bPoolName
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              lastB2bMappingId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cateId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              mappingType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              poolGroupId
 {get; set;}
                                                          
                                                          public  		string
              thirdMappingId
 {get; set;}
                                                          
                                                          public  		string
              outerMappingId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dataSource
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.ware.queryUserToPool";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("businessChannel", this.            businessChannel
);
                                                                                                                                                                                                                        parameters.Add("mappingId", this.            mappingId
);
                                                                                                        parameters.Add("endModifyTime", this.            endModifyTime
);
                                                                                                        parameters.Add("userToPoolSortField", this.            userToPoolSortField
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startCreateTime", this.            startCreateTime
);
                                                                                                        parameters.Add("attributeId", this.            attributeId
);
                                                                                                        parameters.Add("mappingLevel", this.            mappingLevel
);
                                                                                                        parameters.Add("startModifyTime", this.            startModifyTime
);
                                                                                                        parameters.Add("b2bMappingId", this.            b2bMappingId
);
                                                                                                        parameters.Add("cateType", this.            cateType
);
                                                                                                        parameters.Add("wareMappingType", this.            wareMappingType
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("bizPoolType", this.            bizPoolType
);
                                                                                                        parameters.Add("b2bUserToPoolQueryTypeEnum", this.            b2bUserToPoolQueryTypeEnum
);
                                                                                                        parameters.Add("editor", this.            editor
);
                                                                                                        parameters.Add("creator", this.            creator
);
                                                                                                        parameters.Add("totalItem", this.            totalItem
);
                                                                                                        parameters.Add("totalPage", this.            totalPage
);
                                                                                                        parameters.Add("sortTypeEnum", this.            sortTypeEnum
);
                                                                                                        parameters.Add("b2bPoolId", this.            b2bPoolId
);
                                                                                                        parameters.Add("endCreateTime", this.            endCreateTime
);
                                                                                                        parameters.Add("b2bPoolName", this.            b2bPoolName
);
                                                                                                        parameters.Add("lastB2bMappingId", this.            lastB2bMappingId
);
                                                                                                        parameters.Add("cateId", this.            cateId
);
                                                                                                        parameters.Add("mappingType", this.            mappingType
);
                                                                                                        parameters.Add("poolGroupId", this.            poolGroupId
);
                                                                                                        parameters.Add("thirdMappingId", this.            thirdMappingId
);
                                                                                                        parameters.Add("outerMappingId", this.            outerMappingId
);
                                                                                                        parameters.Add("dataSource", this.            dataSource
);
                                                                            }
    }
}





        
 

