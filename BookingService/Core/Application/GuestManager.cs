using Application.Base;
using Application.Guest.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Exceptions;
using Domain.Ports;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);

                await guest.Save(_guestRepository);

                request.Data.Id = guest.Id;

                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (InvalidIdentityDocument exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.INVALID_IDENTITY_DOCUMENT,
                    Message = "The document passed is not valid"
                };
            }
            catch (MissingRequiredInfos exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.MISSING_REQUIRE_INFORMATION,
                    Message = "Missing require infos"
                };
            }
            catch (InvalidEmail exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.INVALID_EMAIL,
                    Message = "The email passed is not valid"
                };
            }
            catch (Exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public async Task<GuestResponse> GetGuest(int id)
        {
            var guest = await _guestRepository.Get(id);

            if (guest is null) return new GuestResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.NOT_FOUND,
                Message = "No Guest record was found with given Id"
            };

            return new GuestResponse
            {
                Data = GuestDTO.MapToDto(guest),
                Success = true,
            };
        }
    }
}