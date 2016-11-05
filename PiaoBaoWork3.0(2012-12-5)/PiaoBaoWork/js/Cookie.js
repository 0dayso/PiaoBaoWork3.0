var HL = HL || {};    
HL.Cookie = {    
/* 
�������ƣ�HL.Cookie.Get([string name]) 
�������ܣ��õ�Cookie 
������name ��ѡ�Ҫȡ�õ�Cookie���� 
˵����nameΪ��ʱ��ͨ��������ʽ����ȫ��Cookie��name��Ϊ��ʱ���ش�Cookie���Ƶ�ֵ��û���κ�ֵʱ����undefined 
*/   
     Get : function(name){    
        var cv = document.cookie.split("; ");//ʹ��"; "�ָ�Cookie    
        var cva = [], cvat = [], cvam = [], temp;    
        /*ѭ���ĵõ�Cookie������ֵ*/   
        for(i=0; i<cv.length; i++){    
             temp = cv[i].split("=");//��"="�ָ�Cookie��������ֵ    
            if(temp[0].indexOf("_divide_") > 0){    
                 cvam[temp[0]] = temp[1];    
             }else{    
                if(temp[0] != "") cvat[i] = [temp[0], temp[1]];    
             }    
         }    
        for(i=0; i<cvat.length; i++){    
            if(cvat[i]){    
                if(cvat[i][1].substr(0,8) != "^divide|"){    
                    /*С��4K��Cookie����*/   
                     cva[cvat[i][0]] = unescape(cvat[i][1]);    
                 }else{    
                    /*����4K��Cookie����*/   
                    var sta = cvat[i][1].indexOf("$"), tot = cvat[i][1].substring(8,sta);    
                     cva[cvat[i][0]] = cvat[i][1].substring(sta+1);    
                    for(j=1; j<tot; j++){    
                         cva[cvat[i][0]] += cvam[cvat[i][0]+"_divide_"+j];    
                     }    
                     cva[cvat[i][0]] = unescape(cva[cvat[i][0]]);    
                 }    
             }    
         }    
        if(name) return cva[name];//�����name��������name��Cookieֵ    
        else return cva;//���û��name�����������Ϊkey��ֵΪValue������    
     },    
/* 
�������ƣ�HL.Cookie.Set(string name, string   value[, int expires[, string path[, string domain[, string secure]]]]) 
�������ܣ�����Cookie 
������name ��Ҫ�Ҫ�����Cookie���� 
       value ��Ҫ�Ҫ�����Cookie���ƶ�Ӧ��ֵ 
       expires ��ѡ�Cookie�Ĺ���ʱ�䣬������������Ϊ��λ�ı���ʱ�䣬Ҳ�����������ڸ�ʽ��wdy, DD-Mon-YYYY HH:MM:SS GMT���ĵ���ʱ�� 
       path ��ѡ�Cookie�ڷ������˵���Ч·�� 
       domain ��ѡ���Cookie����Ч���� 
       secure ��ѡ� ָ��Cookie �Ƿ��ͨ����ȫ�� HTTPS ���Ӵ��ͣ�0��false���ʱΪ�� 
˵��������ɹ��򷵻�true������ʧ�ܷ���false 
*/   
     Set : function(name, value, expires, path, domain, secure, divide){    
        if(!divide) var value = escape(value);    
        if(!name || !value) return false;//���û��name��value�򷵻�false    
        if(name == "" || value == "") return false;//���name��valueΪ���򷵻�false    
        /*���ڹ���ʱ��Ĵ���*/   
        if(expires){    
            /*��������������GMTʱ�䣬��ǰʱ���������Ϊ��λ��expires*/   
            if(/^[0-9]+$/.test(expires)){    
                var today = new Date();    
                 expires = new Date(today.getTime()+expires*1000).toGMTString();    
            /*�ж�expires��ʽ�Ƿ���ȷ������ȷ��ֵΪundefined*/   
             }else if(!/^wed, \d{2} \w{3} \d{4} \d{2}\:\d{2}\:\d{2} GMT$/.test(expires)){    
                 expires = undefined;    
             }    
         }    
        if(name.indexOf("_divide_")< 1 && !divide){    
            this.Del(name, path, domain);//ɾ��ǰһ�δ����Cookie    
         }    
        /*�ϲ�cookie�����ֵ*/   
        var cv = name+"="+value+";"   
                + ((expires) ? " expires="+expires+";" : "")    
                + ((path) ? "path="+path+";" : "")    
                + ((domain) ? "domain="+domain+";" : "")    
                + ((secure && secure != 0) ? "secure" : "");    
        /*�ж�Cookie�ܳ����Ƿ����4K*/   
        if(cv.length < 4096){    
             document.cookie = cv;//д��cookie    
         }else{    
            /*���ڴ���4K��Cookie�Ĳ���*/   
            var max = Math.floor(value.length/3800)+1;    
            for(i=0; i<max; i++){    
                if(i == 0){    
                    this.Set(name, '^divide|'+max+'$'+value.substr(0,3800), expires, path, domain, secure, true);    
                 }else{    
                    this.Set(name+"_divide_"+i, value.substr(i*3800,3800), expires, path, domain, secure, true);    
                 }    
             }    
         }    
        return true;    
     },    
/* 
�������ƣ�HL.Cookie.Del(string name[, string path[, string domain]]) 
�������ܣ�ɾ��Cookie 
������name ��Ҫ�Ҫɾ����Cookie���� 
       path ��ѡ�Ҫɾ����Cookie�ڷ������˵���Ч·�� 
       domain ��ѡ�Ҫɾ����Cookie����Ч���� 
˵����ɾ���ɹ�����true��ɾ��ʧ�ܷ���false 
*/   
     Del : function(name, path, domain){    
        if(!name) return false;//���û��name�򷵻�false    
        if(name == "") return false;//���nameΪ���򷵻�false    
        if(!this.Get(name)) return false;//���Ҫɾ����nameֵ�������򷵻�false    
        /*���ڴ���4K��Cookie���д���*/   
        if(escape(this.Get(name)).length > 3800){    
            var max = Math.floor(escape(this.Get(name)).length/3800)+1;    
            for(i=1; i<max; i++){    
                /*�ϲ�Cookie�����ֵ����ɾ��*/   
                 document.cookie = name+"_divide_"+i+"=;"   
                               + ((path) ? "path="+path+";" : "")    
                               + ((domain) ? "domain="+domain+";" : "")    
                               + "expires=Thu, 01-Jan-1970 00:00:01 GMT;";    
             }    
         }    
        /*�ϲ�Cookie�����ֵ����ɾ��*/   
         document.cookie = name+"=;"   
                           + ((path) ? "path="+path+";" : "")    
                           + ((domain) ? "domain="+domain+";" : "")    
                           + "expires=Thu, 01-Jan-1970 00:00:01 GMT;";    
        return true;    
     }    
}   
