namespace CM.Text
{
    /// <summary>
    ///     TextClientResult status codes
    /// </summary>
    public enum TextClientStatusCode
    {
        /// <summary>
        ///     Ok
        /// </summary>
        Ok = 0,

        /// <summary>
        ///     Authentication failed.
        /// </summary>
        AuthenticationFailed = 101,

        /// <summary>
        ///     Insufficient balance.
        /// </summary>
        BalanceInsufficient = 102,

        /// <summary>
        ///     Incorrect API key.
        /// </summary>
        ApiKeyIncorrect = 103,

        /// <summary>
        ///     This request has one or more errors in its messages. Some or all messages have not been sent.
        /// </summary>
        NotAllSent = 201,

        /// <summary>
        ///     Malformed request
        /// </summary>
        RequestMalformed = 202,

        /// <summary>
        ///     The MSG array is incorrect.
        /// </summary>
        MsgArrayIncorrect = 203,

        /// <summary>
        ///     From field invalid
        /// </summary>
        FromFieldInvalid = 301,

        /// <summary>
        ///     To field invalid
        /// </summary>
        ToFieldInvalid = 302,

        /// <summary>
        ///     MSISDN invalid
        /// </summary>
        MsisdnInvalid = 303,

        /// <summary>
        ///     Body field invalid
        /// </summary>
        BodyFieldInvalid = 304,

        /// <summary>
        ///     Field invalid
        /// </summary>
        FieldInvalid = 305,

        /// <summary>
        ///     Spam filtered
        /// </summary>
        SpamFiltered = 401,

        /// <summary>
        ///     Black listed
        /// </summary>
        BlackListed = 402,

        /// <summary>
        ///     Rejected
        /// </summary>
        Rejected = 403,

        /// <summary>
        ///     Internal server error
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        ///     Unknown error, please contact CM support
        /// </summary>
        Unknown = 999
    }
}
