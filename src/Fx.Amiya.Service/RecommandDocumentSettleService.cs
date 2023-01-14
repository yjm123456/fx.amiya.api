
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class RecommandDocumentSettleService : IRecommandDocumentSettleService
    {
        private IDalRecommandDocumentSettle _dalRecommandDocumentSettle;
        public RecommandDocumentSettleService(IDalRecommandDocumentSettle dalRecommandDocumentSettle)
        {
            _dalRecommandDocumentSettle = dalRecommandDocumentSettle;
        }


        public async Task<List<RecommandDocumentSettleDto>> GetRecommandDocumentSettleAsync(List<string> recommandDocumentIds,bool? isSettle)
        {
            var recommandDocumentSettle = await _dalRecommandDocumentSettle.GetAll().Where(z => !isSettle.HasValue|| z.IsSettle == isSettle).Where(z => recommandDocumentIds.Contains(z.RecommandDocumentId)).ToListAsync();
            List<RecommandDocumentSettleDto> RecommandDocumentSettleDtoList = new List<RecommandDocumentSettleDto>();
            foreach (var z in recommandDocumentSettle)
            {

                RecommandDocumentSettleDto recommandDocumentSettleDto = new RecommandDocumentSettleDto();
                recommandDocumentSettleDto.RecommandDocumentId = z.RecommandDocumentId;
                recommandDocumentSettleDto.OrderId = z.OrderId;
                recommandDocumentSettleDto.DealInfoId = z.DealInfoId;
                recommandDocumentSettleDto.OrderFrom = z.OrderFrom;
                recommandDocumentSettleDto.ReturnBackPrice = z.ReturnBackPrice;
                recommandDocumentSettleDto.CreateDate = z.CreateDate;
                recommandDocumentSettleDto.IsSettle = z.IsSettle;
                RecommandDocumentSettleDtoList.Add(recommandDocumentSettleDto);
            };
            return RecommandDocumentSettleDtoList;

        }

        public async Task AddAsync(AddRecommandDocumentSettleDto addRecommandDocumentSettleDto)
        {
            RecommandDocumentSettle recommandDocumentSettle = new RecommandDocumentSettle();
            recommandDocumentSettle.Id = Guid.NewGuid().ToString();
            recommandDocumentSettle.RecommandDocumentId = addRecommandDocumentSettleDto.RecommandDocumentId;
            recommandDocumentSettle.OrderId = addRecommandDocumentSettleDto.OrderId;
            recommandDocumentSettle.OrderFrom = addRecommandDocumentSettleDto.OrderFrom;
            recommandDocumentSettle.DealInfoId = addRecommandDocumentSettleDto.DealInfoId;
            recommandDocumentSettle.ReturnBackPrice = addRecommandDocumentSettleDto.ReturnBackPrice;
            recommandDocumentSettle.CreateDate = DateTime.Now;
            recommandDocumentSettle.IsSettle = false;
            await _dalRecommandDocumentSettle.AddAsync(recommandDocumentSettle, true);
        }


        public async Task UpdateIsRerturnBackAsync(string Id)
        {
            var result = await _dalRecommandDocumentSettle.GetAll().Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsSettle = true;
                result.SettleDate = DateTime.Now;
                await _dalRecommandDocumentSettle.UpdateAsync(result, true);
            }
        }


    }
}
