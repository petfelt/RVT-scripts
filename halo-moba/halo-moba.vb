
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority local
declare global.number[4] with network priority local = 2
declare global.number[5] with network priority local = 10
declare global.number[6] with network priority local = 1
declare global.number[7] with network priority local
declare global.number[8] with network priority local = 30
declare global.number[9] with network priority low = -1
declare global.number[10] with network priority low
declare global.number[11] with network priority local
declare global.object[0] with network priority local
declare global.object[1] with network priority local
declare global.object[2] with network priority local
declare global.object[3] with network priority local
declare global.player[0] with network priority local
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare player.number[0] with network priority local
declare player.number[1] with network priority low
declare player.number[2] with network priority low
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority low
declare player.number[6] with network priority low
declare player.number[7] with network priority low
declare player.object[0] with network priority low
declare player.object[1] with network priority low
declare player.object[2] with network priority low
declare player.object[3] with network priority local
declare player.timer[0] = 2
declare player.timer[1] = 3
declare player.timer[2] = 5
declare player.timer[3] = 15
declare object.number[0] with network priority low = 250
declare object.number[1] with network priority low
declare object.number[2] with network priority low
declare object.number[3] with network priority low
declare object.number[4] with network priority low = 15
declare object.number[5] with network priority low
declare object.number[6] with network priority low
declare object.number[7] with network priority low
declare object.object[0] with network priority low
declare object.object[1] with network priority low
declare object.player[0] with network priority low
declare object.timer[0] = 90
declare object.timer[1] = 5
declare object.timer[2] = 2

if global.number[6] == -600 then 
   global.number[4] = script_option[1]
   global.number[5] = script_option[2]
   global.number[8] = script_option[5]
   global.number[6] = script_option[3]
end

on local: do
   for each player do
      global.number[3] = 0
      global.object[3] = current_player.biped
      global.object[0] = current_player.biped.place_at_me(hill_marker, none, none, 0, 0, 1, none)
      global.object[0].attach_to(global.object[3], 0, 0, 0, relative)
      global.object[0].detach()
      global.number[3] = current_player.biped.get_distance_to(global.object[0])
      global.object[0].delete()
      if current_player.is_spartan() then 
         if global.number[3] <= 2 and current_player.number[0] == 0 then 
            current_player.number[0] = 1
            current_player.timer[0].reset()
         end
         if global.number[3] >= 3 and current_player.number[0] == 1 then 
            current_player.number[0] = 2
            current_player.timer[0].reset()
         end
         if global.number[3] <= 2 and current_player.number[0] == 2 then 
            current_player.number[0] = 3
            current_player.timer[0].reset()
         end
         if global.number[3] >= 3 and current_player.number[0] == 3 then 
            current_player.number[0] = 4
            current_player.timer[0].reset()
         end
      end
      if current_player.is_elite() then 
         if global.number[3] >= 4 and current_player.number[0] == 3 then 
            current_player.number[0] = 4
            current_player.timer[0].reset()
         end
         if global.number[3] <= 3 and current_player.number[0] == 2 then 
            current_player.number[0] = 3
            current_player.timer[0].reset()
         end
         if global.number[3] >= 4 and current_player.number[0] == 1 then 
            current_player.number[0] = 2
            current_player.timer[0].reset()
         end
         if global.number[3] <= 3 and current_player.number[0] == 0 then 
            current_player.number[0] = 1
            current_player.timer[0].reset()
         end
      end
   end
end

for each object with label "HM_PlayerVars" do
   global.object[3] = current_object
end

for each player do
   current_player.timer[0].set_rate(-100%)
   current_player.timer[1].set_rate(-100%)
   current_player.timer[2].set_rate(-100%)
   current_player.timer[3].set_rate(-100%)
   if current_player.timer[0].is_zero() then 
      current_player.number[0] = 0
   end
   if current_player.number[1] == 0 and current_player.timer[2].is_zero() then 
      current_player.object[3] = global.object[3].place_at_me(capture_plate, none, never_garbage_collect, 0, 0, 0, none)
      game.show_message_to(current_player, inv_spire_vo_spartan_p1_intro, "Halo MOBA\nRemember to jungle!\nCreated by mini nt")
      current_player.set_fireteam(0)
      script_widget[0].set_visibility(current_player, true)
      script_widget[1].set_visibility(current_player, true)
      script_widget[3].set_visibility(current_player, true)
      current_player.score += 5000
      current_player.number[1] = 1
   end
end

for each player do
   if current_player.number[0] == 4 then 
      if current_player.number[7] >= 1 and current_player.object[1] == no_object and current_player.timer[1].is_zero() then 
         current_player.object[1] = current_player.biped.place_at_me(monitor, none, none, 0, 0, 0, none)
         global.object[1] = current_player.object[1]
         global.object[1].player[0] = current_player
         current_player.object[2] = current_player.biped.place_at_me(flag_stand, none, none, 0, 0, -10, none)
         global.object[2] = current_player.object[2]
         global.object[1].attach_to(global.object[2], 0, 0, 1, relative)
         global.object[1].set_scale(201)
         global.object[2].set_scale(268)
         global.object[1].team = current_player.team
         global.object[1].set_shape(cylinder, 35, 10, 100)
         global.object[1].set_shape_visibility(mod_player, current_player, 1)
         global.object[1].set_waypoint_priority(low)
         global.object[1].set_waypoint_range(0, 100)
         global.object[1].set_waypoint_visibility(mod_player, current_player, 1)
         global.object[1].timer[0].reset()
         global.object[1].timer[0].set_rate(-100%)
         current_object.number[1] = 0
         global.object[1].set_waypoint_text("WARD")
         current_player.timer[2].reset()
         current_player.timer[2].set_rate(-100%)
         if global.object[1].is_out_of_bounds() then 
            game.show_message_to(current_player, none, "Wards cannot be placed out of bounds.")
            global.object[1].delete()
         end
         if global.object[1] != no_object then 
            game.show_message_to(current_player, none, "Ward placed.")
            send_incident(respawn_tick_final, current_player, no_player)
         end
         current_player.timer[1].reset()
         current_player.number[0] = 0
      end
      if current_player.number[7] >= 2 and current_player.object[1] != no_object and current_player.timer[1].is_zero() then 
         global.object[0] = current_player.object[1].place_at_me(fusion_coil, "fusion_coil", none, 5, 0, 5, none)
         global.object[1] = current_player.object[1].place_at_me(fusion_coil, "fusion_coil", none, -5, 0, 5, none)
         global.object[2] = current_player.object[1].place_at_me(fusion_coil, "fusion_coil", none, 0, 5, 5, none)
         global.object[3] = current_player.object[1].place_at_me(fusion_coil, "fusion_coil", none, 0, -5, 5, none)
         global.object[0].timer[2].reset()
         global.object[0].timer[2].set_rate(-100%)
         global.object[1].timer[2].reset()
         global.object[1].timer[2].set_rate(-100%)
         global.object[2].timer[2].reset()
         global.object[2].timer[2].set_rate(-100%)
         global.object[3].timer[2].reset()
         global.object[3].timer[2].set_rate(-100%)
         current_player.timer[1].reset()
         current_player.number[0] = 0
      end
   end
   if current_player.number[7] >= 3 then 
      global.object[0] = no_object
      global.object[0] = current_player.try_get_armor_ability()
      global.object[1] = current_player.biped
      global.player[0] = current_player
      global.object[1].set_shape(cylinder, 35, 10, 5)
      if current_player.number[2] == 0 then 
         if global.object[0].is_in_use() then 
            global.object[1].set_shape_visibility(everyone)
            global.object[1].set_waypoint_priority(blink)
            global.object[1].set_waypoint_visibility(everyone)
            global.object[1].set_waypoint_text("WARRIOR")
            for each player do
               if global.object[1].shape_contains(current_player.biped) and current_player != global.player[0] and current_player.team != global.object[1].team then 
                  current_player.biped.set_waypoint_icon(bullseye)
                  current_player.biped.set_waypoint_priority(high)
                  current_player.biped.set_waypoint_visibility(enemies)
                  current_player.apply_traits(script_traits[15])
               end
            end
         end
         if not global.object[0].is_in_use() then 
            global.object[1].set_shape_visibility(no_one)
            global.object[1].set_waypoint_priority(normal)
            global.object[1].set_waypoint_visibility(allies)
            global.object[1].set_waypoint_visibility(mod_player, current_player, 0)
            global.object[1].set_waypoint_icon(none)
            global.object[1].set_waypoint_text("")
            for each player do
               if global.object[1].shape_contains(current_player.biped) and current_player != global.player[0] then 
                  current_player.biped.set_waypoint_icon(none)
                  current_player.biped.set_waypoint_visibility(allies)
                  current_player.biped.set_waypoint_priority(normal)
               end
            end
         end
      end
      if current_player.number[2] == 1 then 
         if global.object[0].is_in_use() then 
            current_player.timer[3].reset()
         end
         if not current_player.timer[3].is_zero() then 
            global.object[1].set_shape_visibility(everyone)
            global.object[1].set_waypoint_priority(blink)
            global.object[1].set_waypoint_visibility(everyone)
            global.object[1].set_waypoint_text("MEDIC")
            global.number[10] = game.round_timer
            global.number[10] %= 2
            for each player do
               if global.object[1].shape_contains(current_player.biped) and current_player != global.player[0] and current_player.team == global.object[1].team and current_player.number[2] != 1 then 
                  global.object[1] = current_player.object[3]
                  global.number[7] = global.object[1].number[0]
                  global.object[1] = global.player[0].biped
                  if global.number[7] <= 0 and global.number[10] == 0 then 
                     current_player.biped.shields += 15
                     global.number[7] = 1
                  end
                  if global.number[7] >= 1 and global.number[10] != 0 then 
                     global.number[7] = 0
                  end
               end
            end
         end
         if current_player.timer[3].is_zero() then 
            global.object[1].set_shape_visibility(no_one)
            global.object[1].set_waypoint_priority(normal)
            global.object[1].set_waypoint_visibility(allies)
            global.object[1].set_waypoint_visibility(mod_player, current_player, 0)
            global.object[1].set_waypoint_text("")
         end
      end
      if current_player.number[2] == 2 then 
         if global.object[0].is_in_use() then 
            global.object[1].set_shape_visibility(everyone)
            global.object[1].set_waypoint_priority(blink)
            global.object[1].set_waypoint_visibility(everyone)
            global.object[1].set_waypoint_text("BESERKER")
            global.number[10] = game.round_timer
            global.number[10] %= 2
            for each player do
               if global.object[1].shape_contains(current_player.biped) and current_player != global.player[0] and current_player.team != global.object[1].team then 
                  global.object[1] = current_player.object[3]
                  global.number[7] = global.object[1].number[0]
                  global.object[1] = global.player[0].biped
                  global.number[11] = current_player.biped.shields
                  if global.number[7] <= 0 and global.number[10] == 0 then 
                     if global.number[11] >= 50 then
                        current_player.biped.shields -= 15
                     end
                     global.number[7] = 1
                  end
                  if global.number[7] >= 1 and global.number[10] != 0 then 
                     if global.number[11] >= 50 then
                        current_player.biped.shields -= 15
                     end
                     global.number[7] = 0
                  end
               end
            end
         end
         if not global.object[0].is_in_use() then 
            global.object[1].set_shape_visibility(no_one)
            global.object[1].set_waypoint_priority(normal)
            global.object[1].set_waypoint_visibility(allies)
            global.object[1].set_waypoint_visibility(mod_player, current_player, 0)
            global.object[1].set_waypoint_text("")
         end
      end
      if current_player.number[2] == 3 then
         global.object[1] = current_player.object[3]
         if not global.object[0].is_in_use() then
            if global.object[1].number[1] == 1 then
               global.object[1].object[1] = current_player.biped.place_at_me(light_yellow_flashing, "PORTAL", never_garbage_collect, 0, 0, 0, none)
               global.object[2] = global.object[1].object[0]
               global.object[2].object[0] = global.object[1].object[1]
               global.object[2].set_waypoint_text("PORTAL")
               global.object[2].set_waypoint_range(0, 5)
               global.object[2].set_waypoint_visibility(everyone)
               global.object[2].timer[0].reset()
               global.object[2].timer[0].set_rate(-100%)
               global.object[2].timer[1].reset()
               global.object[2].timer[1].set_rate(-100%)
               global.object[2] = global.object[1].object[1]
               global.object[2].object[0] = global.object[1].object[0]
               global.object[2].set_waypoint_text("PORTAL")
               global.object[2].set_waypoint_range(0, 5)
               global.object[2].set_waypoint_visibility(everyone)
               global.object[2].timer[0].reset()
               global.object[2].timer[0].set_rate(-100%)
               global.object[2].timer[1].reset()
               global.object[2].timer[1].set_rate(-100%)
               global.object[2] = global.object[1].object[1]
               global.object[2].set_shape(cylinder, 4, 3, 0)
               global.object[2].set_shape_visibility(everyone)
               global.object[1].number[1] = 0
               game.show_message_to(current_player, none, "Halo MOBA")
            end
            global.object[1].set_waypoint_text("")
         end
         if global.object[0].is_in_use() then
            if global.object[1].object[1] != no_object then
               global.object[2] = global.object[1].object[0]
               global.object[2].delete()
               global.object[2] = global.object[1].object[1]
               global.object[2].delete()
            end 
            if global.object[1].number[1] == 0 then
               global.object[1].object[0] = current_player.biped.place_at_me(light_yellow_flashing, "PORTAL", never_garbage_collect, 0, 0, 1, none)
               global.object[2] = global.object[1].object[0]
               global.object[2].set_shape(cylinder, 4, 3, 0)
               global.object[2].set_shape_visibility(everyone)
               game.show_message_to(current_player, none, "slayer")
               global.object[1].number[1] = 1
            end

            global.object[1].set_waypoint_text("RECON")
         end
         
      end
   end
end

for each object with label "fusion_coil" do
   if current_object.timer[2].is_zero() then
      current_object.kill(false)
   end
end

for each object with label "PORTAL" do
   if current_object.timer[0].is_zero() then
      current_object.delete()
      current_object.object[0].delete()
   end
   if current_object.timer[1].is_zero() then
      for each player do
         if current_object.shape_contains(current_player.biped) then
            current_object.timer[1].reset()
            current_object.timer[1].set_rate(-100%)
            global.object[1] = current_object.object[0]
            script_widget[1].set_meter_params(timer, hud_target_object.timer[1])
            script_widget[1].set_visibility(current_player)
            current_player.biped.attach_to(global.object[1], 0, 0, 5, relative)
            current_player.biped.detach()
         end
      end
   end
end

for each player do
   current_player.set_loadout_palette(spartan_tier_1)
end

for each player do
   current_player.set_round_card_icon(attack)
   current_player.set_round_card_text("Halo MOBA")
   if current_player.number[1] == 0 then 
      current_player.set_round_card_title("Use points to upgrade your spartan.\n\nDestroy all enemy towers to win.")
   end
   script_widget[2].set_visibility(current_player, false)
end

for each player do
   global.number[10] = game.round_timer
   global.number[10] %= 2
   if global.number[10] == 0 then 
      script_widget[0].set_text("Dmg: %n/3 Def: %n/2", hud_player.number[3], hud_player.number[4])
      script_widget[1].set_text("%n Spec: %n/3", game.round_timer, hud_player.number[7])
   end
end

for each player do
   global.number[1] = 0
   global.object[0] = current_player.biped
   if global.object[0] != no_object then 
      current_player.object[0] = global.object[0]
   end
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.score -= 0
      current_player.number[5] += 1
      if current_player.killer_type_is(kill) then 
         global.number[11] = global.number[8]
         global.number[11] /= 3
         global.player[0] = current_player.try_get_killer()
         global.player[0].number[5] = 0
         global.number[0] = current_player.get_spree_count()
         global.number[0] *= global.number[11]
         global.number[1] = current_player.number[5]
         global.number[1] *= global.number[11]
         global.number[2] = global.number[8]
         global.number[2] += global.number[0]
         global.number[2] -= global.number[1]
         if global.number[2] >= 100 then 
            global.number[2] = 100
         end
         if global.number[2] <= 10 then 
            global.number[2] = 10
         end
         global.player[0].score += global.number[2]
      end
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) and not current_player.killer_type_is(kill) and not current_player.killer_type_is(betrayal) then 
      current_player.score -= 50
   end
end

for each player do
   if current_player.killer_type_is(betrayal) then 
      global.player[0] = current_player.try_get_killer()
      global.player[0].score -= 50
   end
end

if game.round_time_limit > 0 and game.round_timer.is_zero() then 
   game.end_round()
end

if global.number[9] > 0 then 
   for each player do
      script_widget[2].set_text("GAME OVER")
      script_widget[2].set_visibility(current_player, true)
   end
end

if global.number[9] == game.round_timer then 
   game.end_round()
   global.number[9] = -1
end

for each player do
   global.object[0] = no_object
   global.object[0] = current_player.try_get_armor_ability()
   if global.object[0].is_of_type(armor_lock) then 
      current_player.set_fireteam(0)
   end
   if global.object[0].is_of_type(drop_shield) then 
      current_player.set_fireteam(1)
   end
   if global.object[0].is_of_type(sprint) then 
      current_player.set_fireteam(2)
   end
   if global.object[0].is_of_type(active_camo_aa) then
      current_player.set_fireteam(3)
   end
   current_player.number[2] = current_player.get_fireteam()
end

for each player do
   if current_player.number[2] == 0 then 
      current_player.apply_traits(script_traits[4])
      if current_player.number[3] == 1 then 
         current_player.apply_traits(script_traits[6])
      end
      if current_player.number[3] == 2 then 
         current_player.apply_traits(script_traits[7])
      end
      if current_player.number[3] >= 3 then 
         current_player.apply_traits(script_traits[8])
      end
      if current_player.number[4] == 1 then 
         current_player.apply_traits(script_traits[0])
      end
      if current_player.number[4] >= 2 then 
         current_player.apply_traits(script_traits[1])
      end
   end
   if current_player.number[2] == 1 or current_player.number[2] == 3 then 
      current_player.apply_traits(script_traits[5])
      if current_player.number[3] == 1 then 
         current_player.apply_traits(script_traits[9])
      end
      if current_player.number[3] == 2 then 
         current_player.apply_traits(script_traits[10])
      end
      if current_player.number[3] >= 3 then 
         current_player.apply_traits(script_traits[11])
      end
      if current_player.number[4] == 1 then 
         current_player.apply_traits(script_traits[2])
      end
      if current_player.number[4] >= 2 then 
         current_player.apply_traits(script_traits[3])
      end
   end
   if current_player.number[2] == 2 then 
      if current_player.number[3] == 1 then 
         current_player.apply_traits(script_traits[12])
      end
      if current_player.number[3] == 2 then 
         current_player.apply_traits(script_traits[13])
      end
      if current_player.number[3] >= 3 then 
         current_player.apply_traits(script_traits[14])
      end
      if current_player.number[4] == 1 then 
         current_player.apply_traits(script_traits[2])
      end
      if current_player.number[4] >= 2 then 
         current_player.apply_traits(script_traits[3])
      end
   end
end

for each player do
   global.object[1] = current_player.object[1]
   global.object[2] = current_player.object[2]
   for each player do
      if global.object[1] != no_object then 
         if current_player != global.object[1].player[0] then 
            if global.object[1].shape_contains(current_player.biped) then 
               if current_player.team != global.object[1].team then 
                  current_player.biped.set_waypoint_icon(bullseye)
                  current_player.biped.set_waypoint_priority(high)
                  current_player.biped.set_waypoint_visibility(mod_player, global.object[1].player[0], 1)
               end
               global.object[1].set_waypoint_visibility(mod_player, current_player, 1)
               global.object[1].set_shape_visibility(mod_player, current_player, 1)
            end
            if not global.object[1].shape_contains(current_player.biped) then 
               current_player.biped.set_waypoint_icon(none)
               current_player.biped.set_waypoint_visibility(mod_player, global.object[1].player[0], 0)
               current_player.biped.set_waypoint_priority(normal)
               global.object[1].set_waypoint_visibility(mod_player, current_player, 0)
               global.object[1].set_shape_visibility(mod_player, current_player, 0)
            end
         end
         if global.object[1].timer[0].is_zero() then 
            global.object[1].kill(false)
         end
      end
   end
end

for each player do
   if current_player.object[2] != no_object and current_player.object[1] == no_object then 
      current_player.object[2].delete()
      game.show_message_to(current_player, none, "Your ward was destroyed.")
   end
   if current_player.number[1] != 0 then 
      global.number[10] = game.round_timer
      global.number[10] %= 30
      if global.number[10] == 0 and not current_player.number[1] >= 2 then 
         global.number[4] += global.number[6]
         current_player.number[1] = 2
      end
      global.number[10] = game.round_timer
      global.number[10] %= global.number[5]
      if global.number[10] == 0 and not current_player.number[1] >= 3 then 
         current_player.score += global.number[4]
         current_player.number[1] = 3
      end
      if global.number[10] != 0 then 
         current_player.number[1] = 1
      end
   end
end

for each object with label "HM_Camp" do
   global.object[1] = current_object
   global.number[10] = game.round_timer
   global.number[10] %= 2
   if current_object.number[7] == 0 then 
      current_object.set_shape_visibility(everyone)
      current_object.set_waypoint_visibility(everyone)
      current_object.set_waypoint_priority(low)
      current_object.set_waypoint_range(0, 8)
      current_object.set_waypoint_icon(padlock)
      current_object.number[2] = 1000
      current_object.number[3] = current_object.number[2]
      current_object.number[4] = current_object.number[2]
      current_object.number[4] /= 6
      current_object.timer[1] = 5
      if current_object.spawn_sequence == 21 then 
         current_object.timer[1] = 300
         for each object with label "HM_AreaObj1" do
            if global.object[1].shape_contains(current_object) then 
               current_object.set_invincibility(1)
            end
         end
      end
      if current_object.spawn_sequence == 22 then 
         current_object.timer[1] = 600
      end
      current_object.timer[1].reset()
      current_object.timer[0].reset()
      current_object.set_waypoint_text("")
      current_object.set_waypoint_timer(1)
      current_object.set_waypoint_priority(low)
      for each player do
         if global.object[1].shape_contains(current_player.biped) then 
            script_widget[2].set_text("Camp currently respawning...")
            script_widget[2].set_visibility(current_player, true)
         end
      end
      current_object.number[7] = 1
   end
   current_object.timer[1].set_rate(-100%)
   current_object.timer[0].set_rate(-100%)
   if current_object.timer[1].is_zero() then 
      if current_object.number[7] == 1 or current_object.number[7] == 2 then 
         current_object.set_waypoint_timer(none)
         current_object.set_waypoint_icon(none)
         current_object.set_shape_visibility(everyone)
         current_object.set_waypoint_priority(normal)
         for each player do
            if global.object[1].shape_contains(current_player.biped) then 
               current_player.number[6] = current_object.number[3]
               script_widget[2].set_text("Camp Health: %n", hud_player.number[6])
               script_widget[2].set_visibility(current_player, true)
            end
         end
      end
      if global.number[10] == 0 and current_object.number[7] == 1 then 
         current_object.timer[0] = 20
         if current_object.spawn_sequence == 11 then 
            current_object.set_waypoint_text("ENCAMPMENT")
         end
         if current_object.spawn_sequence == 12 then 
            current_object.set_waypoint_text("WRECKAGE")
         end
         if current_object.spawn_sequence == 13 then 
            current_object.set_waypoint_text("CORNER")
         end
         if current_object.spawn_sequence == 14 then 
            current_object.set_waypoint_text("REFINERY")
         end
         if current_object.spawn_sequence == 21 then 
            current_object.timer[0] = 300
            current_object.set_waypoint_text("MONUMENT")
         end
         if current_object.spawn_sequence == 22 then 
            current_object.timer[0] = 420
            current_object.set_waypoint_text("ABYSS")
         end
         for each player do
            global.number[11] = 0
            if global.object[1].shape_contains(current_player.biped) then 
               if global.object[1].spawn_sequence == 11 or global.object[1].spawn_sequence == 13 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 22
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 22
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 13
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 13
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 5
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 5
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 15
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 45
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 66
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 90
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 60
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 90
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 120
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 45
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 66
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 120
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 180
                        end
                     end
                  end
               end
               if global.object[1].spawn_sequence == 12 or global.object[1].spawn_sequence == 14 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 40
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 40
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 30
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 30
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 25
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 25
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 44
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 60
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 20
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 40
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 60
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 80
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 44
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 80
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 120
                        end
                     end
                  end
               end
               if global.object[1].spawn_sequence >= 20 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 80
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 80
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 55
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 55
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 30
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 30
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 5
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 22
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 30
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 20
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 40
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 22
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 40
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 60
                        end
                     end
                  end
               end
            end
         end
         current_object.number[7] = 2
         if current_object.number[3] <= 0 then 
            current_object.number[3] = 0
            for each player do
               if global.object[1].shape_contains(current_player.biped) then 
                  current_player.score += global.object[1].number[4]
                  current_player.score += global.number[4]
                  current_player.number[6] = 0
                  script_widget[2].set_text("Camp Health: %n", hud_player.number[6])
                  game.show_message_to(current_player, announce_territories_captured, "You destroyed a camp!")
               end
            end
            current_object.number[7] = -1
         end
      end
      if global.number[10] != 0 and current_object.number[7] == 2 then 
         current_object.number[3] += 1
         if current_object.number[3] >= current_object.number[2] then 
            current_object.number[3] = current_object.number[2]
         end
         current_object.number[7] = 1
      end
      if current_object.number[7] == -1 then 
         current_object.set_waypoint_icon(padlock)
         current_object.set_waypoint_text("")
         current_object.set_waypoint_timer(0)
         if current_object.timer[0].is_zero() then 
            current_object.number[2] += 25
            current_object.number[3] = current_object.number[2]
            current_object.number[4] = current_object.number[2]
            current_object.number[4] /= 6
            current_object.number[7] = 1
            current_object.timer[0].reset()
         end
      end
      if not current_object.timer[0].is_zero() and current_object.number[7] == -1 then 
         current_object.set_waypoint_icon(padlock)
         current_object.set_waypoint_text("")
         current_object.set_waypoint_timer(0)
         current_object.set_waypoint_priority(low)
         current_object.set_shape_visibility(no_one)
         for each player do
            if global.object[1].shape_contains(current_player.biped) then 
               script_widget[2].set_text("Camp currently respawning...")
               script_widget[2].set_visibility(current_player, true)
            end
         end
      end
   end
   if not current_object.timer[1].is_zero() then 
      current_object.set_waypoint_icon(padlock)
      current_object.set_waypoint_text("")
      current_object.set_waypoint_timer(1)
      current_object.set_waypoint_priority(low)
      current_object.set_shape_visibility(no_one)
      for each player do
         if global.object[1].shape_contains(current_player.biped) then 
            script_widget[2].set_text("Camp currently respawning...")
            script_widget[2].set_visibility(current_player, true)
         end
      end
   end
end

for each object with label "HM_Tower" do
   global.object[1] = current_object
   global.number[10] = game.round_timer
   global.number[10] %= 2
   if current_object.number[2] == 0 and current_object.number[3] == 0 and current_object.spawn_sequence == 1 then 
      current_object.number[1] = current_object.spawn_sequence
      current_object.set_waypoint_icon(territory_a, current_object.number[1])
      current_object.set_waypoint_visibility(enemies)
      current_object.set_waypoint_priority(high)
      current_object.set_waypoint_range(0, 50)
      current_object.number[2] = current_object.number[0]
      current_object.number[3] = current_object.number[0]
      current_object.number[4] = current_object.number[0]
      current_object.number[4] /= 6
      current_object.number[6] = current_object.number[0]
      current_object.number[7] = 1
      current_object.set_shape_visibility(everyone)
      current_object.number[1] += 1
      global.object[1].object[0] = no_object
      for each object with label "HM_Tower" do
         if current_object.spawn_sequence == global.object[1].number[1] and global.object[1].team == current_object.team then 
            global.object[1].object[0] = current_object
         end
      end
   end
   if current_object.number[2] >= 5000 and current_object.number[3] >= 5000 then 
      current_object.number[1] = current_object.spawn_sequence
      current_object.set_waypoint_icon(territory_a, current_object.number[1])
      current_object.set_waypoint_visibility(enemies)
      current_object.set_waypoint_priority(high)
      current_object.set_waypoint_range(0, 50)
      current_object.number[2] = current_object.number[0]
      current_object.number[3] = current_object.number[0]
      current_object.number[4] = current_object.number[0]
      current_object.number[4] /= 6
      current_object.number[7] = 1
      current_object.set_shape_visibility(everyone)
      current_object.number[1] += 1
      global.object[1].object[0] = no_object
      for each object with label "HM_Tower" do
         if current_object.spawn_sequence == global.object[1].number[1] and global.object[1].team == current_object.team then 
            global.object[1].object[0] = current_object
         end
      end
   end
   if current_object.number[3] > 0 and current_object.number[2] != 0 then 
      for each player do
         global.number[11] = 0
         if global.object[1].shape_contains(current_player.biped) and current_player.team != current_object.team then 
            current_player.number[6] = current_object.number[3]
            script_widget[2].set_text("Tower Health: %n", hud_player.number[6])
            script_widget[2].set_visibility(current_player, true)
            if global.number[10] == 0 and current_object.number[7] == 1 then 
               if global.object[1].spawn_sequence <= 1 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 33
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 33
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 23
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 23
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 13
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 13
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 15
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 45
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 66
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 90
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 60
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 90
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 120
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 45
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 66
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 120
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 180
                        end
                     end
                  end
               end
               if global.object[1].spawn_sequence == 2 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 50
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 50
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 40
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 40
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 30
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 30
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 44
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 60
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 20
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 40
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 60
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 80
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 44
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 80
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 120
                        end
                     end
                  end
               end
               if global.object[1].spawn_sequence >= 3 then 
                  if current_player.number[4] <= 0 then 
                     current_player.biped.shields -= 100
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 100
                     end
                  end
                  if current_player.number[4] == 1 then 
                     current_player.biped.shields -= 75
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 75
                     end
                  end
                  if current_player.number[4] >= 2 then 
                     current_player.biped.shields -= 50
                     global.number[11] = current_player.biped.shields
                     if global.number[11] <= 33 then 
                        current_player.biped.health -= 50
                     end
                  end
                  global.number[11] = current_player.biped.health
                  if global.number[11] >= 1 then 
                     if current_player.number[2] <= 0 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 5
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 22
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 30
                        end
                     end
                     if current_player.number[2] == 1 or current_player.number[2] >= 3 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 20
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 30
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 40
                        end
                     end
                     if current_player.number[2] == 2 then 
                        if current_player.number[3] <= 0 then 
                           global.object[1].number[3] -= 10
                        end
                        if current_player.number[3] == 1 then 
                           global.object[1].number[3] -= 22
                        end
                        if current_player.number[3] == 2 then 
                           global.object[1].number[3] -= 40
                        end
                        if current_player.number[3] >= 3 then 
                           global.object[1].number[3] -= 60
                        end
                     end
                  end
               end
               current_object.number[7] = 0
            end
         end
      end
      if global.number[10] != 0 and current_object.number[7] == 0 then 
         current_object.number[3] += 1
         if current_object.number[3] >= current_object.number[2] then 
            current_object.number[3] = current_object.number[2]
         end
         current_object.number[7] = 1
      end
   end
   if current_object.number[3] <= 0 and current_object.number[2] != 0 then 
      if current_object.object[0] != no_object then 
         global.object[2] = current_object.object[0]
         global.object[2].number[0] = current_object.number[0]
         global.object[2].number[0] += current_object.number[6]
         global.object[2].number[2] = 5000
         global.object[2].number[3] = 5000
      end
      if current_object.object[0] == no_object then 
         for each team do
            if current_team != global.object[1].team then 
               game.show_message_to(current_team, inv_boneyard_vo_spartan_p3_win, "Final Tower Destroyed!")
            end
            if current_team == global.object[1].team then 
               game.show_message_to(current_team, inv_boneyard_vo_spartan_p3_loss, "Final Tower Destroyed!")
            end
         end
         global.number[9] = game.round_timer
         global.number[9] += 12
      end
      current_object.number[2] = current_object.spawn_sequence
      for each player do
         if current_player.team != global.object[1].team then 
            current_player.score += global.object[1].number[4]
            current_player.score += global.number[4]
            if global.object[1].shape_contains(current_player.biped) then 
               current_player.score += global.object[1].number[4]
               current_player.number[6] = 0
               script_widget[2].set_text("Tower Health: %n", hud_player.number[6])
            end
            if current_object.number[2] == 1 then 
               game.show_message_to(current_player, inv_boneyard_vo_spartan_p1_win, "Your team has destroyed an enemy tower!")
            end
            if current_object.number[2] == 2 then 
               game.show_message_to(current_player, inv_spire_vo_spartan_p1_win, "Your team has destroyed an enemy tower!")
            end
            if current_object.number[2] == 3 then 
               game.show_message_to(current_player, inv_spire_vo_spartan_p3_win, "Your team has destroyed an enemy tower!")
            end
            if current_object.number[2] >= 4 then 
               game.show_message_to(current_player, inv_cue_spartan_win_2, "Your team has destroyed an enemy tower!")
            end
         end
         if current_player.team == global.object[1].team then 
            if current_object.number[2] == 1 then 
               game.show_message_to(current_player, inv_boneyard_vo_spartan_p1_intro, "An allied tower has been destroyed!")
            end
            if current_object.number[2] == 2 then 
               game.show_message_to(current_player, inv_spire_vo_spartan_p2_loss, "An allied tower has been destroyed!")
            end
            if current_object.number[2] == 3 then 
               game.show_message_to(current_player, inv_spire_vo_spartan_p1_loss, "An allied tower has been destroyed!")
            end
            if current_object.number[2] >= 4 then 
               game.show_message_to(current_player, boneyard_generator_power_down, "An allied tower has been destroyed!")
            end
         end
      end
      for each object with label "HM_AreaObj1" do
         if global.object[1].shape_contains(current_object) then 
            current_object.delete()
         end
      end
      for each object with label "HM_AreaObj2" do
         if global.object[1].shape_contains(current_object) then 
            current_object.delete()
         end
      end
      for each object with label "HM_TowerDelete" do
         if global.object[1].spawn_sequence == current_object.spawn_sequence then 
            current_object.delete()
         end
      end
      current_object.delete()
   end
end

for each object with label "HM_Help" do
   current_object.set_waypoint_visibility(allies)
   current_object.set_waypoint_priority(low)
   current_object.set_waypoint_range(0, 7)
   current_object.set_shape_visibility(allies)
   current_object.set_waypoint_text("NEED HELP?")
   for each player do
      if current_object.shape_contains(current_player.biped) and current_object.team == current_player.team then 
         current_player.set_round_card_text("NEED HELP?")
         current_player.set_round_card_icon(health_pack)
         current_player.timer[2].set_rate(-100%)
         if current_player.timer[2].is_zero() then 
            if current_player.number[6] == -14 then 
               current_player.number[6] = -1
            end
            if current_player.number[6] == -13 then 
               current_player.set_round_card_title("Good luck, and have fun!\nCreated by mini nt.\n(Version 0.7)")
               game.show_message_to(current_player, announce_oddball_play, "Good luck, and have fun!\nCreated by mini nt.\n(Version 0.7)")
               send_incident(respawn_tick_final, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -12 then 
               current_player.set_round_card_title("SPEC Upgrades give you bonuses\nbased on your current class.\nCheck the INFO shop for more details.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -11 then 
               current_player.set_round_card_title("You can upgrade DMG, DEF, or SPEC.\nUpgrades apply to all classes.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -10 then 
               current_player.set_round_card_title("Beserker is offense-based.\nWarrior is defense-based.\nMedic is the happy medium.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -9 then 
               current_player.set_round_card_title("Purchase upgrades at the\nShops in your home base.\nNeed speed? Teleport or use a mongoose.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -8 then 
               current_player.set_round_card_title("Some camps might give you bonus gear:\nBe especially wary of Abyss and Monument!")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -7 then 
               current_player.set_round_card_title("You recieve points passively. The\namount earned increases over time.\nDestroy camps, towers, & players for more.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -6 then 
               current_player.set_round_card_title("Upgrades can be purchased using points.\nPoints can be gained in a variety of ways.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -5 then 
               current_player.set_round_card_title("Stand under towers or in neutral camps to\ndamage them. They fight back! \nUpgrade your spartan to survive.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -4 then 
               current_player.set_round_card_title("Like other MOBAs, there is:\nThe jungle and the lane with towers.\nThe jungle has neutral camps.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -3 then 
               current_player.set_round_card_title("Welcome to Halo MOBA!\n\nLike other MOBA games, the main goal is\nto smash all enemy towers.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] == -2 then 
               current_player.set_round_card_title("If you're in a lobby: stop reading.\nYou'll figure it out. GO FIGHT!\nNote: All finer details are at the INFO shop.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] -= 1
            end
            if current_player.number[6] >= -1 then 
               current_player.set_round_card_title("Want help?\nStay here for an overview of Halo MOBA.")
               send_incident(respawn_tick, current_player, no_player)
               current_player.number[6] = -2
            end
            current_player.timer[2].reset()
         end
      end
   end
end

for each object with label "HM_Shop" do
   current_object.set_waypoint_visibility(allies)
   current_object.set_waypoint_priority(normal)
   current_object.set_waypoint_range(0, 7)
   current_object.set_shape_visibility(allies)
   if current_object.spawn_sequence == 31 then 
      current_object.set_waypoint_text("DMG SHOP")
   end
   if current_object.spawn_sequence == 32 then 
      current_object.set_waypoint_text("DEF SHOP")
   end
   if current_object.spawn_sequence == 33 then 
      current_object.set_waypoint_text("SPEC SHOP")
   end
   for each player do
      if current_object.shape_contains(current_player.biped) and current_object.team == current_player.team and current_player.timer[1].is_zero() then 
         if current_object.spawn_sequence == 31 then 
            if current_player.number[3] >= 3 then 
               game.show_message_to(current_player, announce_oddball_play, "Stat fully upgraded! No purchase made.")
               current_player.number[6] = 0
            end
            if current_player.number[3] == 2 then 
               current_player.number[6] = 300
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[3] = 3
                  game.show_message_to(current_player, announce_offense, "DMG Upgrade %n purchased.", current_player.number[3])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.number[3] == 1 then 
               current_player.number[6] = 200
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[3] = 2
                  game.show_message_to(current_player, announce_offense, "DMG Upgrade %n purchased.", current_player.number[3])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.number[3] <= 0 then 
               current_player.number[6] = 100
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[3] = 1
                  game.show_message_to(current_player, announce_offense, "DMG Upgrade %n purchased.", current_player.number[3])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.score < current_player.number[6] then 
               game.show_message_to(current_player, announce_oddball_dropped, "Insufficient points! Points needed: %n", current_player.number[6])
            end
         end
         if current_object.spawn_sequence == 32 then 
            if current_player.number[4] >= 2 then 
               game.show_message_to(current_player, announce_oddball_play, "Stat fully upgraded! No purchase made.")
               current_player.number[6] = 0
            end
            if current_player.number[4] == 1 then 
               current_player.number[6] = 200
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[4] = 2
                  game.show_message_to(current_player, announce_defense, "DEF Upgrade %n purchased.", current_player.number[4])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.number[4] <= 0 then 
               current_player.score -= 100
               current_player.number[4] = 1
               current_player.number[6] = 100
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[4] = 1
                  game.show_message_to(current_player, announce_defense, "DEF Upgrade %n purchased.", current_player.number[4])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.score < current_player.number[6] then 
               game.show_message_to(current_player, announce_oddball_dropped, "Insufficient points! Points needed: %n", current_player.number[6])
            end
         end
         if current_object.spawn_sequence == 33 then 
            if current_player.number[7] >= 3 then 
               game.show_message_to(current_player, announce_oddball_play, "Stat fully upgraded! No purchase made.")
               send_incident(respawn_tick_final, current_player, no_player)
               current_player.number[6] = 0
            end
            if current_player.number[7] == 2 then 
               current_player.number[6] = 300
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[7] = 3
                  game.show_message_to(current_player, announce_vip, "SPEC Upgrade %n purchased.", current_player.number[7])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.number[7] == 1 then 
               current_player.number[6] = 200
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[7] = 2
                  game.show_message_to(current_player, announce_vip, "SPEC Upgrade %n purchased.", current_player.number[7])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.number[7] <= 0 then 
               current_player.number[6] = 100
               if current_player.score >= current_player.number[6] then 
                  current_player.score -= current_player.number[6]
                  current_player.number[7] = 1
                  game.show_message_to(current_player, announce_vip, "SPEC Upgrade %n purchased.", current_player.number[7])
                  send_incident(respawn_tick_final, current_player, no_player)
               end
            end
            if current_player.score < current_player.number[6] then 
               game.show_message_to(current_player, announce_oddball_dropped, "Insufficient points! Points needed: %n", current_player.number[6])
            end
         end
         current_player.timer[1].reset()
      end
   end
end

on object death: do
   if killed_object.is_of_type(spartan) or killed_object.is_of_type(elite) or killed_object.is_of_type(monitor) then
      killed_object.set_waypoint_icon(none)
      killed_object.set_waypoint_priority(normal)
      killed_object.set_waypoint_text("")
      killed_object.set_waypoint_visibility(no_one)
      for each player do
         if killed_object.shape_contains(current_player.biped) then
            current_player.biped.set_waypoint_icon(none)
            current_player.biped.set_waypoint_priority(normal)
            current_player.biped.set_waypoint_visibility(allies)
            current_player.biped.set_waypoint_text("")
         end
      end
      killed_object.set_shape(cylinder, 0, 0, 0)
      killed_object.set_shape_visibility(no_one)
   end
end