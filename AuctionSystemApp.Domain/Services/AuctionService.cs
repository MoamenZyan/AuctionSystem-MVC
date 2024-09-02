using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;

namespace AuctionSystemApp.Domain.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IJunctionRepository<AuctionUser> _auctionUserRepository;
        public AuctionService(IRepository<Auction> auctionRepository, 
                                IJunctionRepository<AuctionUser> auctionUserRepository)
        {
            _auctionRepository = auctionRepository;
            _auctionUserRepository = auctionUserRepository;
        }
        public async Task<bool> CreateAuction(Dictionary<string, string> auctionInfo)
        {
            Auction auction = AuctionFactory.CreateAuction(auctionInfo);
            var result = await _auctionRepository.AddAsync(auction);
            if (result == null)
                return false;
            return true;
        }

        public async Task<bool> DeleteAuction(int auctionId)
        {
            return await _auctionRepository.DeleteAsync(auctionId);
        }

        public async Task<List<Auction>?> GetAllAuctions()
        {
            return await _auctionRepository.GetAll();
        }

        public List<Auction>? GetAllUserAuctions(int userId)
        {
            return _auctionRepository.Filter(x => x.UserId == userId);
        }

        public async Task<Auction?> GetAuctionById(int auctionId)
        {
            return await _auctionRepository.GetById(auctionId);
        }
        public async Task<bool> AddUserToAuction(int userId, int auctionId, decimal currentBid)
        {
            AuctionUser auctionUser = AuctionUserFactory.CreateAuctionUser(userId, auctionId, currentBid);
            var result = await _auctionUserRepository.AddAsync(auctionUser);

            return result;
        }

        public async Task<bool> UpdateUserAuction(AuctionUser auctionUser)
        {
            var result = await _auctionUserRepository.UpdateAsync(auctionUser);
            return result;
        }

        public async Task<AuctionUser?> GetUserJoinedAuction(int userId, int auctionId)
        {
            var auctionUser = await _auctionUserRepository.GetByIds(userId, auctionId);
            return auctionUser;
        }

        public async Task<bool> CheckAuctionDeadline(int auctionId)
        {
            var auction = await _auctionRepository.GetById(auctionId);
            if (auction?.AuctionTime.To >= DateTime.Now)
                return true;

            return false;
        }
    }
}
