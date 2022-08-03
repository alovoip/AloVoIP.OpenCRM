using AloVoIP.OpenCRM.Dto;
using PgCrmObjectTypeService;
using PgIdentityService;
using PgUserService;
using Septa.PayamGostarApiClient.CrmObject.ExtendedProperty;
using Septa.PayamGostarApiClient.Invoice.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AloVoIP.OpenCRM.PayamGostar.Helper
{
    public static class Mappers
    {
        public static IdentityDto ToDto(this IdentityInfo identityInfo)
        {
            var toReturn = new IdentityDto()
            {
                Balance = identityInfo.Balance,
                Classification = identityInfo.Classification,
                ColorName = identityInfo.ColorName,
                CustomerDate = identityInfo.CustomerDate,
                CustomerNumber = identityInfo.CustomerNumber,
                DontEmail = identityInfo.DontEmail,
                DontFax = identityInfo.DontFax,
                DontPhoneCall = identityInfo.DontPhoneCall,
                DontSms = identityInfo.DontSms,
                DontSocialSms = identityInfo.DontSocialSms,
                Emails = identityInfo.Emails,
                IdentityType = identityInfo.IdentityType,
                NickName = identityInfo.NickName,
                OtherUsername = identityInfo.OtherUsername,
                SaleUsername = identityInfo.SaleUsername,
                SourceType = identityInfo.SourceType,
                SupportUsername = identityInfo.SupportUsername,
                Website = identityInfo.Website,
                CreateDate = identityInfo.CreatDate,
                CrmId = identityInfo.CrmId.ToStringSafe(),
                CrmObjectTypeCode = identityInfo.CrmObjectTypeCode,
                CrmObjectTypeIndex = identityInfo.CrmObjectTypeIndex,
                CrmObjectTypeName = identityInfo.CrmObjectTypeName,
                ModifyDate = identityInfo.ModifyDate,
                ParentCrmObjectId = identityInfo.ParentCrmObjectId.ToStringSafe(),
                AddressContacts = identityInfo.AddressContacts.Select(ac => ac.ToDto()).ToArray(),
                Categories = identityInfo.Categories.Select(c => c.ToDto()).ToArray(),
                PhoneContacts = identityInfo.PhoneContacts.Select(ac => ac.ToDto()).ToArray(),
                ExtendedProperties = identityInfo.ExtendedProperties.Select(exp => exp.ToDto()).ToArray(),
            };
            return toReturn;
        }
        public static IdentityContactAddressDto ToDto(this IdentityContactAddress identityContactAddress)
        {
            var toReturn = new IdentityContactAddressDto
            {
                Id = identityContactAddress.Id.ToString(),
                RefId = identityContactAddress.RefId,
                Address = identityContactAddress.Address,
                AddressType = identityContactAddress.AddressType,
                AreaCode = identityContactAddress.AreaCode,
                City = identityContactAddress.City,
                Country = identityContactAddress.Country,
                State = identityContactAddress.State,
                ZipBox = identityContactAddress.ZipBox,
                ZipCode = identityContactAddress.ZipCode,
                IsDefault = identityContactAddress.IsDefault,
                IsDeleted = identityContactAddress.IsDeleted,
            };
            return toReturn;
        }
        public static CategoryInfoDto ToDto(this CategoryInfo categoryInfo)
        {
            var toReturn = new CategoryInfoDto
            {
                Id = categoryInfo.Id.ToString(),
                IdentityId = categoryInfo.IdentityId.ToString(),
                Name = categoryInfo.Name,
                IsDeleted = categoryInfo.IsDeleted,
                Key = categoryInfo.Key,
                Type = categoryInfo.Type,
            };
            return toReturn;
        }
        public static BaseCrmObjectExtendedPropertyDto ToDto(this BaseCrmObjectExtendedPropertyInfo baseCrmObjectExtendedPropertyInfo)
        {
            var toReturn = new BaseCrmObjectExtendedPropertyDto
            {
                Key = baseCrmObjectExtendedPropertyInfo.UserKey,
                Name = baseCrmObjectExtendedPropertyInfo.Name,
                Value = baseCrmObjectExtendedPropertyInfo.Value,
            };
            return toReturn;
        }
        public static IdentityContactPhoneDto ToDto(this IdentityContactPhone identityContactPhone)
        {
            var toReturn = new IdentityContactPhoneDto
            {
                Id = identityContactPhone.Id.ToString(),
                RefId=identityContactPhone.RefId,
                IsDefault = identityContactPhone.IsDefault,
                IsDeleted = identityContactPhone.IsDeleted,
                ContinuedNumber = identityContactPhone.ContinuedNumber,
                Extension = identityContactPhone.Extension,
                PhoneNumber = identityContactPhone.PhoneNumber,
                PhoneType = identityContactPhone.PhoneType,
            };
            return toReturn;
        }
        public static UserDto ToDto(this UserInfo userInfo)
        {
            var toReturn = new UserDto()
            {
                Id = userInfo.Id.ToString(),
                IdentityId = userInfo.IdentityId.ToString(),
                Key = userInfo.UserKey,
                NickName = userInfo.NickName,
                TelephonyPassword = userInfo.TelephonyPassword,
                Username = userInfo.Username,
                UserType = (Enums.UserType?)userInfo.UserType,
                Lines = userInfo.Lines.Select(l => l.ToDto()).ToArray(),
                UserGroups = userInfo.UserGroups.Select(ug => ug.ToDto()).ToArray(),
                Message = userInfo.Message,
                Success = userInfo.Success,
            };
            return toReturn;
        }
        public static LineDto ToDto(this LineInfo lineInfo)
        {
            var toReturn = new LineDto
            {
                Id = lineInfo.Id.ToString(),
                CanReceive = lineInfo.CanReceive,
                CanSend = lineInfo.CanSend,
                IsActive = lineInfo.IsActive,
                IsOnline = lineInfo.IsOnline,
                Name = lineInfo.Name,
                MediaType = (Enums.MediaType)lineInfo.MediaType,
            };
            return toReturn;
        }
        public static UserGroupDto ToDto(this UserGroupInfo userGroupInfo)
        {
            var toReturn = new UserGroupDto
            {
                Id = userGroupInfo.Id.ToString(),
                Key = userGroupInfo.UserKey,
                GroupName = userGroupInfo.GroupName,
            };
            return toReturn;
        }
        public static UserTelephonySystemDto ToDto(this UserTelephonySystemInfo userTelephonySystemInfo)
        {
            var toReturn = new UserTelephonySystemDto()
            {
                TelephonySystems = Array.ConvertAll(userTelephonySystemInfo.TelephonySystems, utsi => new TelephonySystemDto
                {
                    OfficeId = utsi.OfficeId.ToString(),
                    BrevityName = utsi.BrevityName,
                    Key = utsi.Key,
                    Name = utsi.Name,
                    ServerAddress = utsi.ServerAddress,
                    Extensions = utsi.Extensions.Select(ext => ext.ToDto()).ToArray(),
                }),
                Message = userTelephonySystemInfo.Message,
                Success = userTelephonySystemInfo.Success,
            };
            return toReturn;
        }
        public static TelephonySystemExtensionDto ToDto(this TelephonySystemExtensionInfo telephonySystemExtensionInfo)
        {
            var toReturn = new TelephonySystemExtensionDto
            {
                Id = telephonySystemExtensionInfo.Id.ToString(),
                Name = telephonySystemExtensionInfo.Name,
                TelephonySystemId = telephonySystemExtensionInfo.TelephonySystemId.ToString(),
                Username = telephonySystemExtensionInfo.Username,
                UserId = telephonySystemExtensionInfo.UserId.ToStringSafe()
            };
            return toReturn;
        }
        public static CardtableResultDto ToDto(this CardtableResultInfo cardtableResult)
        {
            var toReturn = new CardtableResultDto()
            {
                TotalItemsCount = cardtableResult.TotalItemsCount,
                CardtableItems = cardtableResult.CardtableItems.Select(cr => cr.ToDto()).ToArray(),
                Message = cardtableResult.Message,
                Success = cardtableResult.Success,
            };
            return toReturn;
        }
        public static CardtableItemDto ToDto(this CardtableItemInfo cardtableItemInfo)
        {
            var toReturn = new CardtableItemDto
            {
                CrmObjectId = cardtableItemInfo.CrmObjectId.ToString(),
                CrmObjectTypeId = cardtableItemInfo.CrmObjectTypeId.ToStringSafe(),
                EnterCardtableDate = cardtableItemInfo.EnterCardtableDate,
                EnterCardtableDatePersian = cardtableItemInfo.EnterCardtableDatePersian,
                HolderId = cardtableItemInfo.HolderId.ToStringSafe(),
                HolderName = cardtableItemInfo.HolderName,
                IdentityId = cardtableItemInfo.IdentityId.ToStringSafe(),
                IdentityNickName = cardtableItemInfo.IdentityNickName,
                LifePathId = cardtableItemInfo.LifePathId.ToString(),
                ProcessInstanceId = cardtableItemInfo.ProcessInstanceId.ToString(),
                StateId = cardtableItemInfo.StateId.ToStringSafe(),
                StateName = cardtableItemInfo.StateName,
                StateUserKey = cardtableItemInfo.StateUserKey,
                Subject = cardtableItemInfo.Subject,
                CrmObjectType = (Enums.CrmObjectTypes?)cardtableItemInfo.CrmObjectType,
                CardtableStatus = (Enums.CardtableStatus)cardtableItemInfo.CardtableStatus,
                ProcessInstanceType = (Enums.ProcessInstanceType?)cardtableItemInfo.ProcessInstanceType,
                StateActionTypeIndex = (Enums.StateActionType?)cardtableItemInfo.StateActionTypeIndex,
            };
            return toReturn;
        }
        public static SalesInvoiceCreateModel ToSalesInvoiceCreateModel(this CreateSalesInvoiceDto invoice)
        {
            var saleInvoiceCreate = new SalesInvoiceCreateModel
            {
                AdditionalCosts = invoice.AdditionalCosts,
                AssignedToUserName = string.Empty,
                CrmObjectTypeCode = invoice.CrmObjectTypeCode,
                Description = invoice.Description,
                Discount = invoice.Discount,
                DiscountPercent = invoice.DiscountPercent,
                ExpireDate = invoice.ExpireDate,
                FinalValue = invoice.FinalValue,
                IdentityId = invoice.IdentityId,
                InvoiceDate = invoice.InvoiceDate,
                RefId = invoice.RefId,
                Subject = invoice.Subject,
                Toll = invoice.Toll,
                TollPercent = Convert.ToInt32(invoice.TollPercent),
                TotalDiscountPercent = invoice.TotalDiscountPercent,
                TotalValue = invoice.TotalValue,
                Vat = invoice.Vat,
                VatPercent = Convert.ToInt32(invoice.VatPercent),
                Number = string.Empty,
                ParentCrmObjectId = string.Empty,
                PriceListName = string.Empty,
                RelatedQuoteId = string.Empty,
                StageId = string.Empty,
                Tags = new List<string>().ToArray(),
                ExtendedProperties = invoice.ExtendedProperties.Select(ep => new ExtendedPorpertyCreateModel()
                {
                    Name = ep.Name,
                    Value = ep.Value,
                    UserKey = ep.Key
                }).ToList(),
                Details = invoice.ProductDetails.Select(pd => new Septa.PayamGostarApiClient.Invoice.InvoiceDetailModel()
                {
                    BaseUnitPrice = pd.BaseUnitPrice,
                    Count = pd.Count,
                    DetailDescription = pd.DetailDescription,
                    DiscountPercent = pd.DiscountPercent,
                    FinalUnitPrice = pd.FinalUnitPrice,
                    InventoryCode = pd.InventoryCode,
                    InventoryName = pd.InventoryName,
                    IsService = pd.IsService,
                    ProductCode = pd.ProductCode,
                    ProductId = pd.ProductId,
                    ProductName = pd.ProductName,
                    ProductUnitTypeName = pd.ProductUnitTypeName,
                    ReturnedCount = pd.ReturnedCount,
                    Serial = pd.Serial,
                    TotalDiscount = pd.TotalDiscount,
                    TotalToll = pd.TotalToll,
                    TotalUnitPrice = pd.TotalUnitPrice,
                    TotalVat = pd.TotalVat
                }).ToList(),
            };
            return saleInvoiceCreate;
        }
    }
}
