import os
import sys
from subprocess import Popen
from PIL import Image, ImageTk
import tkinter
import time
import socket
import threading
import datetime

msg=""

piclist=[]
vidlist=[]

bind_ip = '0.0.0.0'
bind_port = 5007

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((bind_ip, bind_port))
server.listen(5)  # max backlog of connections
checkhr='26'
checkmin='61'
timex=''



os.system('killall omxplayer.bin')

def showfiles(code):
    if code=='pic':
        for root, dirs, files in os.walk("/home/pi/Pictures/."):
            files1="";
            for filename in files:
                files1+=":"+filename
            print (files1)
            return files1
    if code=='vid':
        for root, dirs, files in os.walk("/home/pi/Videos/."):
            files1="";
            for filename in files:
                files1+=":"+filename
            print (files1)
            return files1

def handle_client_connection(client_socket):
    global msg
    global time
    global piclist
    global vidlist
    global checkhr
    global checkmin
    global timex
    request = client_socket.recv(1024)
    req=request.decode("utf-8")
    print(req)
    print ('Received {}'.format(request))
    if req=='vid':
        msg=showfiles(req)
        print("vid")
    if req=='pic':
        msg=showfiles(req)
        print("pic")
    if "spic" in req:
        i=0
        temp="";
        piclist=req.split(":")
        print(piclist)
        display_time_img=int(piclist[1])
    if "svid" in req:
        i=0
        temp="";
        vidlist=req.split(":")
        display_time_movie=int(vidlist[1])
    if "start" in req:
        xyz=str(datetime.datetime.time(datetime.datetime.now()))
        timex=xyz
        msg="start";
    if "time" in req:
        msg=str(datetime.datetime.time(datetime.datetime.now()))
        timex=msg;
        print("X")
    if "time2" in req:
        abc=req.split(":")
        checkhr=abc[1]
        checkmin=abc[2]
        print(abc[1])
        print(abc[2])

        
    
    client_socket.send(bytes(msg,'utf-8'))
    client_socket.close()

def showPIL(pilImage):
    root = tkinter.Tk()
    w, h = root.winfo_screenwidth(), root.winfo_screenheight()
    root.overrideredirect(1)
    root.geometry("%dx%d+0+0" % (w, h))
    root.focus_set()    
    canvas = tkinter.Canvas(root,width=w,height=h)
    canvas.pack()
    canvas.configure(background='black')
    imgWidth, imgHeight = pilImage.size
    if imgWidth > w or imgHeight > h:
        ratio = min(w/imgWidth, h/imgHeight)
        imgWidth = int(imgWidth*ratio)
        imgHeight = int(imgHeight*ratio)
        pilImage = pilImage.resize((imgWidth,imgHeight), Image.ANTIALIAS)
    image = ImageTk.PhotoImage(pilImage)
    imagesprite = canvas.create_image(w/2,h/2,image=image)
    root.after(display_time_img, lambda: root.destroy())
    root.mainloop()
    
x=1
print (datetime.datetime.time(datetime.datetime.now()))
print ('Listening on {}:{}'.format(bind_ip, bind_port))

while (msg!="start"):
    client_sock, address = server.accept()
    print ('Accepted connection from {}:{}'.format(address[0], address[1]))
    client_handler = threading.Thread(
        target=handle_client_connection,
        args=(client_sock,)  # without comma you'd get a... TypeError: handle_client_connection() argument after * must be a sequence, not _socketobject
        
    )
    
    client_handler.start()
    if msg=='start':
            break

while x==1:
    k=2

    print ('reset')
    yy=timex.split(':')
    print(yy[0])
    print(yy[1])
    if int(yy[0])==int(checkhr) and int(yy[1])==int(checkmin):
        sys.exit()
    global display_time_img
    if len(piclist)>2:
        display_time_img=int(piclist[1])*1000
    #open(file)
    if len(piclist)>2:
        while k!=(len(piclist)-1):
            timex=str(datetime.datetime.time(datetime.datetime.now()))
            im="/home/pi/Pictures/"+piclist[k] 
            pilImage = Image.open(im)
            showPIL(pilImage)
            k=k+1
            
        #time.sleep(5)
    
    global display_time_movie
    if len(vidlist)>2:
        display_time_movie=int(vidlist[1])
    
    y=2
    if len(vidlist)>2:
        while y!=len(vidlist):
            timex=str(datetime.datetime.time(datetime.datetime.now()))
            movie1="/home/pi/Videos/"+vidlist[y]
            omxc = Popen(['omxplayer', '-b', movie1])
            time.sleep(display_time_movie)
            os.system('killall omxplayer.bin')
            y=y+1
        #i=i+1 
    
        
    

