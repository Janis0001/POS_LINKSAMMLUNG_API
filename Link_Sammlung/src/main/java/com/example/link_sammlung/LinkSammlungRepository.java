package com.example.link_sammlung;

import org.springframework.data.mongodb.repository.MongoRepository;

public interface LinkSammlungRepository extends MongoRepository<Link, String> {
        //public Link findByLink(String linktype);
}

