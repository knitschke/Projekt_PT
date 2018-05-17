import os
import sys
from subprocess import Popen
from PIL import Image, ImageTk
import tkinter
import time
mv="/home/pi/Videos/HEY.mp4"
im="/home/pi/Pictures/p1.jpg"
im2="/home/pi/Pictures/p2.jpg"
file="/home/pi/Documents/a.pdf"

display_time_img=5000
display_time_movie=15
movie1 = (mv)



os.system('killall omxplayer.bin')

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
while(x==1):
    #open(file)
    pilImage = Image.open(im)
    showPIL(pilImage)
    pilImage = Image.open(im2)
    showPIL(pilImage)
    omxc = Popen(['omxplayer', '-b', movie1])
    time.sleep(display_time_movie)
    os.system('killall omxplayer.bin')
    
    
