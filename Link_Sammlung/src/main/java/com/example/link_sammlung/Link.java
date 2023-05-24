package com.example.link_sammlung;

import org.springframework.data.annotation.Id;

import java.time.Clock;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Date;

public class Link {

        @Id
        public String id;

        public String linkName;
        public String linkURL;
        public String erstellung;

    public void setLinkName(String linkName) {
        this.linkName = linkName;
    }
    public String getLinkName() {
        return linkName;
    }

    public void setLinkURL(String linkURL) {
        this.linkURL = linkURL;
    }
    public String getLinkURL(){
        return linkURL;
    }

    public void setId(String id) {
        this.id = id;
    }
    public String getId() {
        return id;
    }

    public void setErstellung(String erstellung) {
        this.erstellung = erstellung;
    }
    public String getErstellung(){
        return erstellung;
    }



    public Link(String id, String linkName, String linkURL, String erstellung){
            this.id = id;
            this.linkName = linkName;
            this.linkURL = linkURL;
            DateTimeFormatter format = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");
            erstellung = LocalDateTime.now(Clock.systemDefaultZone()).format(format);

        }

        @Override
        public String toString() {
            return String.format(
                    "Link[id=%s, linkName='%s', linkURL='%s', erstellung='%s']",
                    id, linkName, linkURL, erstellung);
        }

}

