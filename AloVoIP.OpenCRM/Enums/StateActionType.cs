﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AloVoIP.OpenCRM.Enums
{
    public enum StateActionType : int
    {
        Cardtable = 1,
        Decision = 2,
        SendSms = 3,
        SendEmail = 4,
        SendFax = 5,
        SendPrint = 6,
        ApproveBillableObject = 7,
        Assignment = 8,
        Final = 9,
        SetOpportunityStage = 10,
        RejectBillableObject = 11,
        SendHttpRequest = 12,
        ApproveInventoryTransaction = 13,
        RejectInventoryTransaction = 14,
        Wait = 15,
        FollowUp = 16,
        Task = 17,
        CreateUser = 18,
        Membership = 19,
        Condition = 20,
        StartProcess = 21,
        BlackList = 22,
        SendSocialSms = 23,
        UpdateExternalResourceField = 24,
        Opportunity = 25,
        ConvertCrmObject = 26,
        CreateAppointment = 27,
        CustomerNumber = 28,
        PaymentLink = 29,
    }
}
