using AutoMapper;
using FluentValidation;
using KafeAPI.Application.Dtos.CafeInfoDtos;
using KafeAPI.Application.Dtos.ResponseDtos;
using KafeAPI.Application.Interfaces;
using KafeAPI.Application.Services.Abstract;
using KafeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAPI.Application.Services.Concrete
{
    public class CafeInfoServices : ICafeInfoServices
    {
        private readonly IGenericRepository<CafeInfo> _cafeInfoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCafeInfoDto> _createValidator;
        private readonly IValidator<UpdateCafeInfoDto> _updateValidator;

        public CafeInfoServices(IGenericRepository<CafeInfo> cafeInfoRepository, IMapper mapper, IValidator<CreateCafeInfoDto> createValidator, IValidator<UpdateCafeInfoDto> updateValidator)
        {
            _cafeInfoRepository = cafeInfoRepository;
            this._mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<ResponseDto<object>> AddCafeInfoDto(CreateCafeInfoDto dto)
        {
            try
            {
                var validate = await _createValidator.ValidateAsync(dto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError,
                        Message = validate.Errors.Select(x => x.ErrorMessage).FirstOrDefault()
                    };
                }
                var cafeInfo = _mapper.Map<CafeInfo>(dto);
                await _cafeInfoRepository.AddAsync(cafeInfo);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = null,
                    Message = "Kafe bilgisi başarılı bir şekilde eklendi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir Hata Oluştu."
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteCafeInfoDto(int id)
        {
            try
            {
                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(id);
                if(cafeInfo == null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                await _cafeInfoRepository.DeleteAsync(cafeInfo);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = null,
                    Message = "Kafe bilgisi başarılı bir şekilde silindi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir Hata Oluştu."
                };
            }
        }

        public async Task<ResponseDto<List<ResultCafeInfoDto>>> GetAllCafeInfos()
        {
            try
            {
                var cafeInfo = await _cafeInfoRepository.GetAllAsync();
                if(cafeInfo == null || !cafeInfo.Any())
                {
                    return new ResponseDto<List<ResultCafeInfoDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                var result = _mapper.Map<List<ResultCafeInfoDto>>(cafeInfo);
                return new ResponseDto<List<ResultCafeInfoDto>>
                {
                    Success = true,
                    Data = result
                };

            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ResultCafeInfoDto>>
                {
                    Success = false,
                    Data = null,
                    ErrorCode = "Bir Hata Oluştu."
                };
            }
        }

        public async Task<ResponseDto<DetailCafeInfoDto>> GetByIdCafeInfo(int id)
        {
            try
            {
                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(id);
                if(cafeInfo == null)
                {
                    return new ResponseDto<DetailCafeInfoDto>
                    {
                        Success = false,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                var result = _mapper.Map<DetailCafeInfoDto>(cafeInfo);
                return new ResponseDto<DetailCafeInfoDto>
                {
                    Success = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<DetailCafeInfoDto>
                {
                    Success = false,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir Hata Oluştu."
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateCafeInfoDto(UpdateCafeInfoDto dto)
        {
            try
            {
                var validate = await _updateValidator.ValidateAsync(dto);
                if (!validate.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCode = ErrorCodes.ValidationError,
                        Message = validate.Errors.Select(x => x.ErrorMessage).FirstOrDefault()
                    };
                }
                var cafeInfo = await _cafeInfoRepository.GetByIdAsync(dto.Id);
                if(cafeInfo == null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCode = ErrorCodes.NotFound,
                        Message = "Kafe bilgisi bulunamadı."
                    };
                }
                var result = _mapper.Map(dto, cafeInfo);
                await _cafeInfoRepository.UpdateAsync(result);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = null,
                    Message = "Kafe bilgisi başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    ErrorCode = ErrorCodes.Exception,
                    Message = "Bir Hata Oluştu."
                };
            }
        }
    }
}
