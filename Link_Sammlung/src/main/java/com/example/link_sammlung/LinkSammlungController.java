package com.example.link_sammlung;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class LinkSammlungController {

    @Autowired
    LinkSammlungService LinkSammlungService;

    @RequestMapping(method = RequestMethod.POST, value="/addLink")
    public String addLink(@RequestBody Link link) {
        LinkSammlungService.addLink(link);
        String response = "{\"success\": true, \"message\": Link has been added successfully.}";
        return response;
    }

    @RequestMapping(method = RequestMethod.PUT, value="/editLink/{id}")
    public String editLink(@RequestBody Link link, @PathVariable String id) {
        LinkSammlungService.editLink(id, link);
        String response = "{\"success\": true, \"message\": Link has been edited successfully.}";
        return response;
    }

    @DeleteMapping(value="/deleteLink/{id}")
    public String deleteNotiz(@PathVariable String id) {
        LinkSammlungService.deleteLink(id);
        String response = "{\"success\": true, \"message\": Link has been deleted successfully.}";
        return response;
    }

    @RequestMapping("/Link")
    public List<Link> getallInfo() {return LinkSammlungService.getAll();}

    @RequestMapping(method = RequestMethod.GET, value = "/status")
    public String getStatus() {
        return "Server ist erreichbar";
    }
}
