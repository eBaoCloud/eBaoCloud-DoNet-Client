﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ebaocloud.client.thai.seg.cmi.parameters;

namespace com.ebaocloud.client.thai.seg.cmi.pub
{
    class Utils
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string FormatDate(DateTime time)
        {
            return time.ToString("dd/MM/yyyyTHH:mm:ss.fff");
        }


	}
}
