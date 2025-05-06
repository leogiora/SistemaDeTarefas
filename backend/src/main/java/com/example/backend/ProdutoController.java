package com.exemplo.backend.controller;

import com.exemplo.backend.model.Produto;
import com.exemplo.backend.repository.ProdutoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/produtos")
@CrossOrigin(origins = "*") // permite acesso do frontend
public class ProdutoController {

    @Autowired
    private ProdutoRepository repository;

    @GetMapping
    public Page<Produto> listar(@RequestParam(defaultValue = "0") int page,
                                @RequestParam(defaultValue = "5") int size) {
        return repository.findAll(PageRequest.of(page, size));
    }

    @PostMapping
    public Produto criar(@RequestBody Produto produto) {
        return repository.save(produto);
    }
}
