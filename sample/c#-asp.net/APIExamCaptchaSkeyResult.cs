﻿using System;
using System.Net;
using System.Text;
using System.IO;

namespace NaverAPI_Guide
{
    public class APIExamCaptchaSkeyResult
    {
        static void Main(string[] args)
        {
          string code = "1"; // 키 발급시 0,  캡차 이미지 비교시 1로 세팅
          string key = "KEY-INPUT";  // 캡차 키 발급시 받은 키값
          string value = "VALUE-INPUT";  // 사용자가 입력한 캡차 이미지 글자값
          string url = "https://openapi.naver.com/v1/captcha/skey?code=" + code + "&key=" + key + "&value=" + value;
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          request.Headers.Add("X-Naver-Client-Id", "YOUR-CLIENT-ID");
          request.Headers.Add("X-Naver-Client-Secret", "YOUR-CLIENT-SECRET");
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          string status = response.StatusCode.ToString();
          if(status == "OK")
          {
              Stream stream = response.GetResponseStream();
              StreamReader reader = new StreamReader(stream, Encoding.UTF8);
              string text = reader.ReadToEnd();
              Console.WriteLine(text);
          }
          else
          {
              Console.WriteLine("Error 발생=" + status);
          }
        }
    }
}
