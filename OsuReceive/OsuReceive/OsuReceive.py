from BaseHTTPServer import HTTPServer, BaseHTTPRequestHandler
import io,shutil  
import urllib
import os, sys

class MyRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        mpath,margs=urllib.splitquery(self.path) 
        strs = margs.split('=')
        SongId = strs[1]
        print "SongIdGet:",SongId
        self.do_action("receive Song,Id = :",SongId)

    def do_POST(self):
        mpath,margs=urllib.splitquery(self.path)
        datas = self.rfile.read(int(self.headers['content-length']))
        self.do_action(mpath, datas)


    def do_action(self, path, args):
            self.outputtxt(path + args )

    def outputtxt(self, content):
        #指定返回编码
        enc = "UTF-8"
        content = content.encode(enc)          
        f = io.BytesIO()
        f.write(content)
        f.seek(0)  
        self.send_response(200)  
        self.send_header("Content-type", "text/html; charset=%s" % enc)  
        self.send_header("Content-Length", str(len(content)))  
        self.end_headers()  
        shutil.copyfileobj(f,self.wfile)


http_server = HTTPServer(('127.0.0.1', int(8000)), MyRequestHandler)  
http_server.serve_forever() #设置一直监听并接收请求  

