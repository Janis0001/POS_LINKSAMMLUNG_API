package com.example.link_sammlung;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.List;

@Service

public class LinkSammlungService {
    @Autowired
    LinkSammlungRepository LinkSammlungRepository;

    public void addLink(Link link) {this.LinkSammlungRepository.save(link);}

    public void editLink(String id, Link link) {
        this.LinkSammlungRepository.deleteById(id);
        link.setId(id);
        this.LinkSammlungRepository.save(link);
    }

    public void deleteLink(String id) {this.LinkSammlungRepository.deleteAllById(Collections.singleton(id));}

    public List<Link> getAll() {return (List<Link>)this.LinkSammlungRepository.findAll();}
}
