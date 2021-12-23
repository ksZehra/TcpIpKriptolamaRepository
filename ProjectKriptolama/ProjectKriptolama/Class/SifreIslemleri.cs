using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace ProjectKriptolama.Class
{
    public class SifreIslemleri
    {
        public static byte[] ByteDonustur(string deger)
        {

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetBytes(deger);

        }

        public static byte[] Byte8(string deger)
        {
            char[] arrayChar = deger.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }

        #region HASH ŞİFRELEME
        public string MD5(string strGiris)
        {
            try
            {
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok");
                }
                else
                {
                    //// MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
                    //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    ////Parametre olarak gelen veriyi byte dizisine dönüştürdük.
                    //byte[] dizi = Encoding.UTF8.GetBytes(strGiris);
                    ////dizinin hash'ini hesaplattık.
                    //dizi = md5.ComputeHash(dizi);
                    ////Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
                    //StringBuilder sb = new StringBuilder();
                    ////Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

                    //foreach (byte ba in dizi)
                    //{
                    //    sb.Append(ba.ToString("x2").ToLower());
                    //}

                    ////hexadecimal(onaltılık) stringi geri döndürdük.
                    //return sb.ToString();

                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strGiris, "md5");
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string SHA1(string strGiris)
        {
            try
            {
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok.");
                }
                else
                {
                    //SHA1CryptoServiceProvider sifre = new SHA1CryptoServiceProvider();
                    //byte[] arySifre = ByteDonustur(strGiris);
                    //byte[] aryHash = sifre.ComputeHash(arySifre);
                    //return BitConverter.ToString(aryHash);

                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strGiris, "sha1");
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string SHA256(string strGiris)
        {
            try
            {
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek Veri Yok");
                }
                else
                {
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strGiris, "sha256");
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string SHA384(string strGiris)
        {
            try
            {
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri bulunamadı.");
                }
                else
                {
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strGiris, "sha384");
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string SHA512(string strGiris)
        {
            try
            {
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok.");
                }
                else
                {
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(strGiris, "sha512");
                }
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        #endregion


        #region SİMETRİK ŞİFRELEME - DEŞİFRELEME
        public string DESSifrele(string strGiris, string key)
        {
            try
            {
                string sonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new Exception("Şifrelenecek veri yok!");
                }
                else
                {
                    if (key.Length != 8)
                    {
                        throw new Exception("Anahtar uzunluğu 8 karakterden farklı olamaz!");
                    }

                    byte[] aryKey = Byte8(key); // BURAYA 8 bit string DEĞER GİRİN
                    byte[] aryIV = Byte8(key); // BURAYA 8 bit string DEĞER GİRİN
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(strGiris);
                    writer.Flush();
                    cs.FlushFinalBlock();
                    writer.Flush();
                    sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    writer.Dispose();
                    cs.Dispose();
                    ms.Dispose();

                    //UTF8Encoding utf8Enc = new UTF8Encoding();
                    //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    //des.Key = utf8Enc.GetBytes(key);
                    //des.Mode = CipherMode.ECB;
                    //ICryptoTransform encryptor = des.CreateEncryptor();
                    //byte[] arrayByte = utf8Enc.GetBytes(strGiris);
                    //byte[] enc = encryptor.TransformFinalBlock(arrayByte, 0, arrayByte.Length);
                    //sonuc = Convert.ToBase64String(enc);
                }
                return sonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string DESCoz(string strGiris, string key)
        {
            try
            {
                string strSonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new Exception("Şifrelenecek veri yok!");
                }
                else
                {
                    if (key.Length != 8)
                    {
                        throw new Exception("Anahtar uzunluğu 8 karakterden farklı olamaz!");
                    }

                    byte[] aryKey = Byte8("12345678");
                    byte[] aryIV = Byte8("12345678");
                    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                    StreamReader reader = new StreamReader(cs);
                    strSonuc = reader.ReadToEnd();
                    reader.Dispose();
                    cs.Dispose();
                    ms.Dispose();

                    //UTF8Encoding utf8Enc = new UTF8Encoding();
                    //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    //des.Key = utf8Enc.GetBytes(key);
                    //des.Mode = CipherMode.ECB;
                    //ICryptoTransform decryptor = des.CreateDecryptor();
                    //byte[] arrayByte = utf8Enc.GetBytes(strGiris);
                    //byte[] enc = decryptor.TransformFinalBlock(arrayByte, 0, arrayByte.Length);
                    //strSonuc = Convert.ToBase64String(enc);
                }
                return strSonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }


        //TripleDES algoritması 24 bit anahtar ve 8 bit iv değeri kullanır.
        public string TDESSifrele(string strGiris)
        {
            try
            {
                string sonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok.");
                }
                else
                {
                    byte[] aryKey = Byte8("123456781234567812345678");
                    byte[] aryIV = Byte8("12345678");
                    TripleDESCryptoServiceProvider dec = new TripleDESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, dec.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(strGiris);
                    writer.Flush();
                    cs.FlushFinalBlock();
                    writer.Flush();
                    sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    writer.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return sonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string TDESCoz(string strGiris)
        {
            try
            {
                string strSonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok.");
                }
                else
                {
                    byte[] aryKey = Byte8("123456781234567812345678");
                    byte[] aryIV = Byte8("12345678");
                    TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                    StreamReader reader = new StreamReader(cs);
                    strSonuc = reader.ReadToEnd();
                    reader.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return strSonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }

        public string TDESEncrypt(string TextToEncrypt, string mysecurityKey)
        {
            try
            {
                byte[] MyEncryptedArray = UTF8Encoding.UTF8
                   .GetBytes(TextToEncrypt);

                MD5CryptoServiceProvider MyMD5CryptoService = new
                   MD5CryptoServiceProvider();

                byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
                   (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

                MyMD5CryptoService.Clear();

                var MyTripleDESCryptoService = new
                   TripleDESCryptoServiceProvider();

                MyTripleDESCryptoService.Key = MysecurityKeyArray;

                MyTripleDESCryptoService.Mode = CipherMode.ECB;

                MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var MyCrytpoTransform = MyTripleDESCryptoService
                   .CreateEncryptor();

                byte[] MyresultArray = MyCrytpoTransform
                   .TransformFinalBlock(MyEncryptedArray, 0,
                   MyEncryptedArray.Length);

                MyTripleDESCryptoService.Clear();

                return Convert.ToBase64String(MyresultArray, 0,
                   MyresultArray.Length);
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string TDESDecrypt(string TextToDecrypt, string mysecurityKey)
        {
            try
            {
                byte[] MyDecryptArray = Convert.FromBase64String
                   (TextToDecrypt);

                MD5CryptoServiceProvider MyMD5CryptoService = new
                   MD5CryptoServiceProvider();

                byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
                   (UTF8Encoding.UTF8.GetBytes(mysecurityKey));

                MyMD5CryptoService.Clear();

                var MyTripleDESCryptoService = new
                   TripleDESCryptoServiceProvider();

                MyTripleDESCryptoService.Key = MysecurityKeyArray;

                MyTripleDESCryptoService.Mode = CipherMode.ECB;

                MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var MyCrytpoTransform = MyTripleDESCryptoService
                   .CreateDecryptor();

                byte[] MyresultArray = MyCrytpoTransform
                   .TransformFinalBlock(MyDecryptArray, 0,
                   MyDecryptArray.Length);

                MyTripleDESCryptoService.Clear();

                return UTF8Encoding.UTF8.GetString(MyresultArray);
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }


        //RC2 algoritması 8 bit anahtar ve 8 bit iv değeri kullan
        public string RC2Sifrele(string strGiris, string key)
        {
            try
            {
                string sonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new Exception("Şifrelenecek veri yok!");
                }
                else
                {
                    if (key.Length != 8)
                    {
                        throw new Exception("Anahtar uzunluğu 8 karakterden farklı olamaz!");
                    }

                    byte[] aryKey = Byte8(key); //8 bit string
                    byte[] aryIV = Byte8(key); //8 bit string
                    RC2CryptoServiceProvider dec = new RC2CryptoServiceProvider();
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, dec.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(strGiris);
                    writer.Flush();
                    cs.FlushFinalBlock();
                    writer.Flush();
                    sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    writer.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return sonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string RC2Coz(string strGiris, string key)
        {
            try
            {
                string strSonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new Exception("Şifresi çözülecek veri yok!");
                }
                else
                {
                    byte[] aryKey = Byte8(key); //8 bit string
                    byte[] aryIV = Byte8(key); //8 bit string
                    RC2CryptoServiceProvider cp = new RC2CryptoServiceProvider();
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                    CryptoStream cs = new CryptoStream(ms, cp.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                    StreamReader reader = new StreamReader(cs);
                    strSonuc = reader.ReadToEnd();
                    reader.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return strSonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }


        //Rijndael algoritması 8 anahtar ve 16 bit iv değeri kullanır.
        public string RijndaelSifrele(string strGiris, string key)
        {
            try
            {
                string sonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrelenecek veri yok.");
                }
                else
                {
                    byte[] aryKey = Byte8(key);
                    byte[] aryIV = Byte8(key + key);
                    RijndaelManaged dec = new RijndaelManaged();
                    dec.Mode = CipherMode.CBC;
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, dec.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write);
                    StreamWriter writer = new StreamWriter(cs);
                    writer.Write(strGiris);
                    writer.Flush();
                    cs.FlushFinalBlock();
                    writer.Flush();
                    sonuc = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    writer.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return sonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        public string RijndaelCoz(string strGiris, string key)
        {
            try
            {
                string strSonuc = "";
                if (strGiris == "" || strGiris == null)
                {
                    throw new ArgumentNullException("Şifrezi çözülecek veri yok.");
                }
                else
                {
                    byte[] aryKey = Byte8(key);
                    byte[] aryIV = Byte8(key + key);
                    RijndaelManaged cp = new RijndaelManaged();
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                    CryptoStream cs = new CryptoStream(ms, cp.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                    StreamReader reader = new StreamReader(cs);
                    strSonuc = reader.ReadToEnd();
                    reader.Dispose();
                    cs.Dispose();
                    ms.Dispose();
                }
                return strSonuc;
            }
            catch (Exception myExp)
            {
                throw myExp;
            }
        }
        #endregion
    }
}