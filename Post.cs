private void SendJsonString(string url, string jsonToSend) {    
    var data = Encoding.ASCII.GetBytes(jsonToSend);
    var req = WebRequest.Create(url);
    req.ContentType = "application/json";
    req.Method = "POST";
    req.ContentLength = data.Length;
    req.Timeout = 1800000; //System.Threading.Timeout.Infinite;

    using (var stream = req.GetRequestStream()) {
        var bufferLengthS = 8000;
        var offset = 0;
        while (offset < data.Length) {
            if (offset + bufferLengthS > data.Length) {
                bufferLengthS = data.Length - offset;
            }
            stream.Write(data, offset, bufferLengthS);
            offset += bufferLengthS;
        }
        stream.Close();
    }
}
