﻿package com.ankamagames.dofus.internalDatacenter.communication
{

    public class ThinkBubble extends Object implements IDataCenter
    {
        private var _text:String;

        public function ThinkBubble(param1:String)
        {
            this._text = param1;
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

    }
}