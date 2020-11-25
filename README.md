# AzureBlobUploader
Project for university project - showing and uploading photos on azure blob.

It was used in the Blazor server project because the Blazor client does not support encryption dll (used to connect to azure).

![Screenshot_1](docs/screenshot_0001.png)

secrets.json schema

```
{
  "AzureConfiguration": {
    "AccountName": "",
    "AccountKey": "",
    "ImageBlobName": ""
  }
}
```
