﻿using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ScottBrady.Pem.NetCore
{
    public class Program
    {
        private const string CertPem = @"MIIB3zCCAYWgAwIBAgIUImttQCULqkHxYbDivb1fzRNFYG8wCgYIKoZIzj0EAwIw
RTELMAkGA1UEBhMCQVUxEzARBgNVBAgMClNvbWUtU3RhdGUxITAfBgNVBAoMGElu
dGVybmV0IFdpZGdpdHMgUHR5IEx0ZDAeFw0yMDA5MTgxNDQyMzlaFw0yMTA5MTMx
NDQyMzlaMEUxCzAJBgNVBAYTAkFVMRMwEQYDVQQIDApTb21lLVN0YXRlMSEwHwYD
VQQKDBhJbnRlcm5ldCBXaWRnaXRzIFB0eSBMdGQwWTATBgcqhkjOPQIBBggqhkjO
PQMBBwNCAARwfxEb6RX+fwiz70spEdLTfK/ite5ZGfysbalM/ZlnUjWZ+Cwk+aEc
KkER2GWoZ6Fiw3PcOlQzY8dGHMdkkHhGo1MwUTAdBgNVHQ4EFgQUOYFYa+w94G7t
MGD3bpM3T04WAxswHwYDVR0jBBgwFoAUOYFYa+w94G7tMGD3bpM3T04WAxswDwYD
VR0TAQH/BAUwAwEB/zAKBggqhkjOPQQDAgNIADBFAiEAxX7N6e+2NfuwR70u3AX0
mx5ZP9uQhdrvOi8qDBHSMMoCIEQenUMtTfYfOU8FwT3WZO4S5JB5jvPg9hCnlXPj
NwaC";
        private const string EccPem = @"MHcCAQEEIP7n5rwD8HN7VUqcyYD5p+5jBNZQGkQEzoZ76tjXd2TmoAoGCCqGSM49
AwEHoUQDQgAEcH8RG+kV/n8Is+9LKRHS03yv4rXuWRn8rG2pTP2ZZ1I1mfgsJPmh
HCpBEdhlqGehYsNz3DpUM2PHRhzHZJB4Rg==";
        
        public static void Main()
        {
            // parsing a cert from a PEM file. PEM labels have been stripped
            var cert = new X509Certificate2(Convert.FromBase64String(CertPem));
            Console.WriteLine($"Certificate loaded with subject '{cert.Subject}' and a key type of '{cert.PublicKey.Oid.FriendlyName}'");

            // parsing an ECC key from a PEM file. PEM labels have been stripped
            var key = ECDsa.Create();
            key.ImportECPrivateKey(Convert.FromBase64String(EccPem), out _);
            Console.WriteLine($"Key loaded with key size of '{key.KeySize}'");

            var certWithPrivateKey = cert.CopyWithPrivateKey(key);
        }
    }
}
